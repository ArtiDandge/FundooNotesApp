// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRegistration.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooRepository
{
    using System.Linq;
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interfaces;
  
    /// <summary>
    /// UserRegistration class implements IUserRegistration interface
    /// </summary>
    public class UserRegistration : IUserRegistration
    {
        /// <summary>
        /// Field userContext of type UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegistration" /> class.
        /// </summary>
        /// <param name="userContext">userContext Parameter</param>
        public UserRegistration(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Method to Add new User to the Database
        /// </summary>
        /// <param name="user">user parameter for this method</param>
        /// <returns>string message</returns>
        public string AddNewUser(RegistrationModel user)
        {
            this.userContext.Users.Add(user);
            this.userContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        /// <summary>
        /// Method for Login
        /// </summary>
        /// <param name="email">user email parameter </param>
        /// <param name="password">user password parameter</param>
        /// <returns>string message</returns>
        public string Login(string email, string password)
        {
            string message;
            var login = this.userContext.Users
                        .Where(x => x.UserEmail == email && x.UserPassword == password).SingleOrDefault();
            if (login != null)
            {
                message = "LOGIN SUCCESS";
            }
            else
            {
                message = "LOGIN UNSUCCESSFUL";
            }

            return message;
        }

        /// <summary>
        /// Method to Implement Forgot password functionality.
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>string message</returns>
        public string ForgotPassword(string email)
        {
            string user;
            var userCheck = this.userContext.Users
                            .SingleOrDefault(x => x.UserEmail == email);
            if (userCheck != null)
            {
                user = userCheck.UserPassword;
                return "Link for Password reset sent Successfully on given mail !";
            }
            else
            {
                return "Error while sending mail !";
            }
        }
    }
}
