// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRegistration.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooRepository
{
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using Experimental.System.Messaging;
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interfaces;
    using Microsoft.EntityFrameworkCore;

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
            var url = "https://localhost:44340/ResetPassword.html";
            MessageQueue msmqQueue = new MessageQueue();
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                msmqQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                msmqQueue = MessageQueue.Create(@".\Private$\MyQueue");

            }
            Message message = new Message();
            message.Formatter = new BinaryMessageFormatter();
            message.Body = url;
            msmqQueue.Label = "url link";
            msmqQueue.Send(message);
            var reciever = new MessageQueue(@".\Private$\MyQueue");
            var recieving = reciever.Receive();
            recieving.Formatter = new BinaryMessageFormatter();
            string linkToBeSend = recieving.Body.ToString();

            string user;
            string mailSubject = "Link to reset your FundooNotes App Credentials";
            var userCheck = this.userContext.Users
                            .SingleOrDefault(x => x.UserEmail == email);
            if (userCheck != null)
            {
                user = linkToBeSend;
                using (MailMessage mailMessage = new MailMessage("dartis2512@gmail.com", email))
                {
                    mailMessage.Subject = mailSubject;
                    mailMessage.Body = user;
                    mailMessage.IsBodyHtml = true;
                    SmtpClient Smtp = new SmtpClient();
                    Smtp.Host = "smtp.gmail.com";
                    Smtp.EnableSsl = true;
                    Smtp.UseDefaultCredentials = false;
                    Smtp.Credentials = new NetworkCredential("dartis2512@gmail.com", "Arti@1234567890");
                    Smtp.Port = 587;
                    Smtp.Send(mailMessage);
                }
                return "Mail Sent Successfully !";
            }
            else
            {
                return "Error while sending mail !";
            }
        }

        /// <summary>
        /// Method to reset old user password with new one.
        /// </summary>
        /// <param name="resetPassword">variable of type ResetPasswordModel</param>
        /// <returns>string message</returns>
        public string ResetPassword(ResetPasswordModel resetPassword)
        {
            var userPassword = this.userContext.Users
                            .SingleOrDefault(x => x.UserEmail == resetPassword.UserEmail);
            if (userPassword != null)
            {
                userPassword.UserPassword = resetPassword.UserPassword;
                userContext.Entry(userPassword).State = EntityState.Modified;
                userContext.SaveChanges();
                return "Password Reset Successfull ! ";
            }
            else
            {
                return "Error While Resetting Password !";
            }
        }
    }
}
