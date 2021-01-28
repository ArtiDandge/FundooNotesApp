// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRegistration.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooRepository
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using Experimental.System.Messaging;
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using StackExchange.Redis;

    /// <summary>
    /// UserRegistration class implements IUserRegistration interface
    /// </summary>
    public class UserRegistration : IUserRegistration
    {
        /// <summary>
        /// SINGING KEY for SECRET KEY 
        /// </summary>
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(UserRegistration.SECRET_KEY));

        /// <summary>
        /// SECRETE KEY string
        /// </summary>
        private const string SECRET_KEY = "This is Secret key for valid user authentication";

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
            user.UserPassword = encryptPassword(user.UserPassword);
            this.userContext.Users.Add(user);
            this.userContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        /// <summary>
        /// Method to Encrypt User Password
        /// </summary>
        /// <param name="password">user password</param>
        /// <returns>encrypted password</returns>
        public string encryptPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            password = Convert.ToBase64String(encrypt);
            return password;
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
            string encodedPassword = encryptPassword(password);
            var login = this.userContext.Users
                        .Where(x => x.UserEmail == email && x.UserPassword == encodedPassword).SingleOrDefault();
                        
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
        /// Method to generate token for given User Email
        /// </summary>
        /// <param name="UserEmail">User Email address</param>
        /// <returns>returns string JWT token</returns>
        public string GenerateToken(string UserEmail)
        {
            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name, UserEmail)
                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                signingCredentials: new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Method to Implement Forgot password functionality using SMTP and MSMQ .
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>string message</returns>
        public string ForgotPassword(string email)
        {
            var url = "Click on following link to reset your credentials for Fundoonotes App: https://localhost:44340/ResetPassword.html";
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
            string encodedPassword = encryptPassword(resetPassword.UserPassword);
            var userPassword = this.userContext.Users
                            .SingleOrDefault(x => x.UserEmail == resetPassword.UserEmail);
            if (userPassword != null)
            {
                userPassword.UserPassword = encodedPassword;
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
