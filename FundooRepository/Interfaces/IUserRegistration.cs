// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRegistration.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Interfaces
{
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
        /// <returns>boolean result</returns>
        public bool AddNewUser(RegistrationModel user);

        /// <summary>
        /// Login Method Declaration  
        /// </summary>
        /// <param name="email">user email parameter</param>
        /// <param name="password">user password parameter</param>
        /// <returns>string result</returns>
        public string Login(string email, string password);

        /// <summary>
        /// Forgot password method Declaration
        /// </summary>
        /// <param name="email">user string</param>
        /// <returns>boolean result</returns>
        public bool ForgotPassword(string email);

        /// <summary>
        /// Reset Password Method
        /// </summary>
        /// <param name="resetPassword">Reset Password</param>
        /// <returns>boolean result</returns>
        public bool ResetPassword(ResetPasswordModel resetPassword);

        /// <summary>
        /// Method to Generate Token
        /// </summary>
        /// <param name="UserEmail">User Email</param>
        /// <returns>string result</returns>
        public string GenerateToken(string UserEmail);
    }
}
