using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
