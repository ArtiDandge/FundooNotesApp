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
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }
    }
}
