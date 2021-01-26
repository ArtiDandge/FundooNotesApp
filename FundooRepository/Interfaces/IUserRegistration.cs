using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interfaces
{
    public interface IUserRegistration
    {
        public string AddNewUser(RegistrationModel user);
    }
}
