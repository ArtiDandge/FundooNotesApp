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
       
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="manager">manager parameter for this constructor</param>
        public UserController(IUserManager manager)
        {
            this.manager = manager;
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
            try
            {
                var result = this.manager.AddNewUser(user);
                if (result.Equals("SUCCESS"))
                {
                    return this.Ok(new { success = true, Message = "New User Added Successfully !", Data = user });
                }

                return this.BadRequest(new { success = false, Message = "Failed to Add New User to Data to Database"});
            }
            catch (Exception ex)
            {
                return this.NotFound(new { success = false, Message = ex.Message });
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
            try
            {
                var result = this.manager.Login(login.UserEmail, login.UserPassword);
                if (result.Equals("LOGIN SUCCESS"))
                {
                    string tokenString = this.manager.GenerateToken(login.UserEmail);
                    return this.Ok(new { success = true, Message = "Login Successfully", Data = login,tokenString });
                }
 
                return this.BadRequest(new { success = false, Message = "Failed to Login. Email Id or Password is mismatched." });
             }
            catch(Exception ex)
            {
                return this.NotFound(new { success = false, Message = ex.Message });
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
                var result = this.manager.ForgotPassword(email);
                if (result.Equals("Mail Sent Successfully !"))
                {
                    return this.Ok(new { success = true, Message = "Link has sent to the given email address to reset the password", Data = email });
                }

                return this.BadRequest(new { success = false, Message = "Unable to sent link to given email address. This Email doesn't exist in database." });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller method for Reset password method invocation
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult ResetPassword(ResetPasswordModel resetPassword)
        {
            try
            {
                var result = this.manager.ResetPassword(resetPassword);
                if (result.Equals("Password Reset Successfull ! "))
                {
                    return this.Ok(new { success = true, Message = "Password Reset Successfully", Data = resetPassword });
                }
                
                return this.BadRequest(new { success = false, Message = "Failed to Reset Password. This Email doesn't exist in database." });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { success = false, Message = ex.Message });
            }
        }
    }
}
