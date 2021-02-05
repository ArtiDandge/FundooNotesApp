// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using FundooManager.Interfaces;
    using FundooModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// UserController Class 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Field 'manager' of type IUserManager
        /// </summary>
        private readonly IUserManager manager;

        private readonly ILogger<UserController> _logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="manager">manager parameter for this constructor</param>
        public UserController(IUserManager manager, ILogger<UserController> _logger)
        {
            this.manager = manager;
            this._logger = _logger;
        }

        /// <summary>
        /// UserRegistration method for New User Registration
        /// </summary>
        /// <param name="user">user parameter</param>
        /// <returns>Response from this API</returns>
        [HttpPost]
        [Route("newUser")]
        public IActionResult UserRegistration([FromBody]RegistrationModel user)
        {
            _logger.LogInformation("The API for Adding new User has accessed");
            try
            {
                var result = this.manager.AddNewUser(user);
                _logger.LogInformation("new User added successfully");
                if (result.Equals("SUCCESS"))
                {
                    return this.Ok(new ResponseModel<RegistrationModel>(){Status = true, Message = result, Data = user });
                }

                return this.BadRequest(new ResponseModel<RegistrationModel>(){ Status = false, Message = result });
            }
            catch (Exception ex)
            {
                _logger.LogWarning("An Exception caugth while adding new user"+ ex.Message);
                return this.NotFound(new ResponseModel<RegistrationModel>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Login method for User login
        /// </summary>
        /// <param name="login">login parameter</param>
        /// <returns>Response from API</returns>
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            _logger.LogInformation("The API for User Login has accessed");
            try
            {
                var message = this.manager.Login(login.UserEmail, login.UserPassword);
                if (message.Equals("LOGIN SUCCESS"))
                {
                    _logger.LogInformation("User Logged Login Successfull!");
                    string tokenString = this.manager.GenerateToken(login.UserEmail);
                    return this.Ok(new { Status = true, Message = message, Data = login,tokenString });
                }
 
                return this.BadRequest(new ResponseModel<LoginModel>() { Status = false, Message = message });
             }
            catch(Exception ex)
            {
                _logger.LogWarning("Exception encountered while log in "+ ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }            
        }

        /// <summary>
        /// Controller method for Forgot password method invocation
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>Response from API</returns>
        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                _logger.LogInformation("The API for Forgot Password has accessed");
                var message = this.manager.ForgotPassword(email);
                if (message.Equals("Link has sent to the given email address to reset the password"))
                {
                    _logger.LogInformation("Link has sent to given gmail to reset password");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = message, Data = email });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception encountered while sending link to given mail address" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller method for Reset password method invocation
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                _logger.LogInformation("The API for Reset Password has accessed");
                var message = this.manager.ResetPassword(resetPassword);
                if (message.Equals("Password Reset Successfull ! "))
                {
                    _logger.LogInformation("Password has reset successfully");
                    return this.Ok(new ResponseModel<ResetPasswordModel>() { Status = true, Message = message, Data = resetPassword });
                }
                
                return this.BadRequest(new { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception encountered while resetting the poassword" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
