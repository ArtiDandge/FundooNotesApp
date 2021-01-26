using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundooRepository.Interfaces;
using FundooModels;

namespace FundooNotes.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserRegistration userContext;
        public UserController(IUserRegistration userContext)
        {
            this.userContext = userContext;
        }

        [HttpPost]
        [Route("api/newUser")]
        public IActionResult UserRegistration([FromBody]RegistrationModel user)
        {
            var result = this.userContext.AddNewUser(user);
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
