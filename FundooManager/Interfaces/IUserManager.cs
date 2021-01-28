﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooManager.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooModels;

    /// <summary>
    /// IUserManager Interface
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// AddNewUser Method Declaration
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

        /// <summary>
        /// Reset Password Method Declaration
        /// </summary>
        /// <param name="email">user string</param>
        /// <param name="password">user password</param>
        /// <param name="confirmPassword">confirm Password</param>
        /// <returns>string message</returns>
        public string ResetPassword(ResetPasswordModel resetPassword);

        /// <summary>
        /// Method to Generate Token
        /// </summary>
        /// <param name="UserEmail">User Email</param>
        /// <returns>string token</returns>
        public string GenerateToken(string UserEmail);
    }
}
