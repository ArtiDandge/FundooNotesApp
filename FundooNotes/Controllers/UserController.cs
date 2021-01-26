using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundooRepository.Interfaces;
using FundooModels;
using FundooManager.Interfaces;

namespace FundooNotes.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;
        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

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

        [HttpPost]
        [Route("api/Login")]
        public IActionResult Login([FromBody] RegistrationModel user)
        {
            var result = this.manager.Login(user.UserEmail, user.UserPassword);
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
