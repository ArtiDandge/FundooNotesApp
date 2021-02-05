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
        /// <returns>boolean result</returns>
        public bool AddNewUser(RegistrationModel user)
        {
            try
            {
                bool result = this.userRegistration.AddNewUser(user);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to call Login Method which belongs to IUserRegistration interface
        /// </summary>
        /// <param name="email">user email</param>
        /// <param name="password">user password</param>
        /// <returns>string result</returns>
        public string Login(string email, string password)
        {
            try
            {
                 string result = this.userRegistration.Login(email, password);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        /// <summary>
        /// Forgot password Method 
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>boolean result</returns>
        public bool ForgotPassword(string email)
        {
            try
            {
                 bool result = this.userRegistration.ForgotPassword(email);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Reset Password Method 
        /// </summary>
        /// <param name="resetPassword">variable of type ResetPasswordModel</param>
        /// <returns>boolean result</returns>
        public bool ResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                 bool result = this.userRegistration.ResetPassword(resetPassword);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GenerateToken(string UserEmail)
        {
            try
            {
                string token = this.userRegistration.GenerateToken(UserEmail);
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
