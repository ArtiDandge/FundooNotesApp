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
    using FundooModels;
    using FundooMSMQ;
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
        private const string SECRET_KEY = "SuperSecretKey@345fghhhhhhhhhhhhhhhhhhhhhhhhhhhhhfggggggg";

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
        /// <returns>boolean result</returns>
        public bool AddNewUser(RegistrationModel user)
        {
            try
            {
                bool result;
                if (user != null)
                {
                    user.UserPassword = encryptPassword(user.UserPassword);
                    this.userContext.Users.Add(user);
                    this.userContext.SaveChanges();
                    result = true;
                    return result;
                }

                result = false;
                return result;
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        /// <summary>
        /// Method to Encrypt User Password
        /// </summary>
        /// <param name="password">user password</param>
        /// <returns>encrypted password</returns>
        public string encryptPassword(string password)
        {
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] encrypt;
                UTF8Encoding encode = new UTF8Encoding();
                //encrypt the given password string into Encrypted data  
                encrypt = md5.ComputeHash(encode.GetBytes(password));
                password = Convert.ToBase64String(encrypt);
                return password;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Method for Login
        /// </summary>
        /// <param name="email">user email parameter </param>
        /// <param name="password">user password parameter</param>
        /// <returns>string message</returns>
        public string Login(string email, string password)
        {
            try
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
                    message = "LOGIN UNSUCCESSFUL, Email Or Password is Wrong";
                }

                return message;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Method to generate token for given User Email
        /// </summary>
        /// <param name="UserEmail">User Email address</param>
        /// <returns>returns string JWT token</returns>
        public string GenerateToken(string UserEmail)
        {
            try
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
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Method to Implement Forgot password functionality using SMTP and MSMQ .
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>boolean result</returns>
        public bool ForgotPassword(string email)
        {
            try
            {
                bool result;
                string user;
                string mailSubject = "Link to reset your FundooNotes App Credentials";
                var userCheck = this.userContext.Users.SingleOrDefault(x => x.UserEmail == email);
                if (userCheck != null)
                {
                    Sender sender = new Sender();
                    sender.SendMessage();
                    Receiver receiver = new Receiver();
                    var messageBody = receiver.receiverMessage();
                    user = messageBody;
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

                    result = true;
                    return result; 
                }
               
                result = false;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        /// <summary>
        /// Method to reset old user password with new one.
        /// </summary>
        /// <param name="resetPassword">variable of type ResetPasswordModel</param>
        /// <returns>boolean result</returns>
        public bool ResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                bool result;
                string encodedPassword = encryptPassword(resetPassword.UserPassword);
                var userPassword = this.userContext.Users.SingleOrDefault(x => x.UserEmail == resetPassword.UserEmail);
                if (userPassword != null)
                {
                    userPassword.UserPassword = encodedPassword;
                    userContext.Entry(userPassword).State = EntityState.Modified;
                    userContext.SaveChanges();

                    result = true;
                    return result;
                }
                
                result = false;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
