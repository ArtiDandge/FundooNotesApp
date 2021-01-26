using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FundooRepository
{
    public class UserRegistration: IUserRegistration
    {
        UserContext userContext;
        public UserRegistration(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public string AddNewUser(RegistrationModel user)
        {
            this.userContext.Users.Add(user);
            this.userContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        public string Login(string email, string password)
        {
            string message;
            var Login = this.userContext.Users
                        .Where(x => x.UserEmail == email && x.UserPassword == password).SingleOrDefault();
            if (Login != null)
            {
                message = "LOGIN SUCCESS";
            }
            else
            {
                message = "LOGIN UNSUCCESSFUL";

            }
            return message;
        }
    }
}
