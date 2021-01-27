// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRegistration.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooModels;

    /// <summary>
    /// Interface for User Registration 
    /// </summary>
    public interface IUserRegistration
    {
        /// <summary>
        /// AddNewUser() Method Declaration
        /// </summary>
        /// <param name="user">user parameter for this method</param>
        /// <returns>string message</returns>
        public string AddNewUser(RegistrationModel user);

        /// <summary>
        /// Login Method Declaration  
        /// </summary>
        /// <param name="email">user email parameter</param>
        /// <param name="password">user password parameter</param>
        /// <returns>string message</returns>
        public string Login(string email, string password);

        /// <summary>
        /// Forgot password method Declaration
        /// </summary>
        /// <param name="email">user string</param>
        /// <returns>string message</returns>
        public string ForgotPassword(string email);
    }
}
