using FundooManager.Interfaces;
using FundooModels;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRegistration userRegistration;
        
        public UserManager(IUserRegistration userRegistration)
        {
            this.userRegistration = userRegistration;
        }

        public string AddNewUser(RegistrationModel user)
        {
            string message = this.userRegistration.AddNewUser(user);
            return message;
        }

        public string Login(string email, string password)
        {
            string message = this.userRegistration.Login(email, password);
            return message;
        }
    }
}
