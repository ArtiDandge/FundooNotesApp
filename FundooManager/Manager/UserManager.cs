// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooManager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooManager.Interfaces;
    using FundooModels;
    using FundooRepository.Interfaces;

    /// <summary>
    /// UserManager class implements IUserManager interface
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// userRegistration reference variable of type IUserRegistration
        /// </summary>
        private readonly IUserRegistration userRegistration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager" /> class.
        /// </summary>
        /// <param name="userRegistration">userRegistration parameter</param>
        public UserManager(IUserRegistration userRegistration)
        {
            this.userRegistration = userRegistration;
        }

        /// <summary>
        /// Method to call AddNewUser Method which belongs to IUserRegistration interface
        /// </summary>
        /// <param name="user">user parameter</param>
        /// <returns>string message</returns>
        public string AddNewUser(RegistrationModel user)
        {
            string message = this.userRegistration.AddNewUser(user);
            return message;
        }

        /// <summary>
        /// Method to call Login Method which belongs to IUserRegistration interface
        /// </summary>
        /// <param name="email">user email</param>
        /// <param name="password">user password</param>
        /// <returns>string message</returns>
        public string Login(string email, string password)
        {
            string message = this.userRegistration.Login(email, password);
            return message;
        }
    }
}
