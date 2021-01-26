using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interfaces
{
    public interface IUserManager
    {
        public string AddNewUser(RegistrationModel user);
        public string Login(string email, string password);
    }
}
