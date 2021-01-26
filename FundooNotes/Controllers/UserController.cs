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

    /// <summary>
    /// UserController Class 
    /// </summary>
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
        [Authorize]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var result = this.manager.Login(login.UserEmail, login.UserPassword);
            if (result.Equals("LOGIN SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Login Successfully", Data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Failed to Login" });
            }
        }
    }
}
