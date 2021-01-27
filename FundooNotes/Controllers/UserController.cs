// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using FundooManager.Interfaces;
    using FundooModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;

    /// <summary>
    /// UserController Class 
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Field 'manager' of type IUserManager
        /// </summary>
        private readonly IUserManager manager;
        private const string SECRET_KEY = "This is Secret key for valid user authentication";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(UserController.SECRET_KEY));
       
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
        [Route("api/newUser")]
        public IActionResult UserRegistration([FromBody]RegistrationModel user)
        {
            var result = this.manager.AddNewUser(user);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "New User Added Successfully", Data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Failed to Add New User to Data to Database" });
            }
        }

        /// <summary>
        /// Login method for User login
        /// </summary>
        /// <param name="login">login parameter</param>
        /// <returns>Response from API</returns>
        [HttpPost]
        [Route("api/Login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var result = this.manager.Login(login.UserEmail, login.UserPassword);
            if (result.Equals("LOGIN SUCCESS"))
            {
                string tokenString = GenerateToken(login.UserEmail);
                return this.Ok(new { success = true, Message = "Login Successfully", Data = result, tokenString });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Failed to Login. Email Id or Password is mismatched." });
            }
        }

        private string GenerateToken(string UserEmail)
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
    }
}
