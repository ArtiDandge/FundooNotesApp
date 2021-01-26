using FundooManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class TokenController : Controller
    {
        private const string SECRET_KEY = "this is my custom Secret key for authnetication";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenController.SECRET_KEY));
        private readonly IUserManager manager;
        public TokenController(IUserManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [Route("api/Token/{userEmail}/{password}")]
        public IActionResult Get(string userEmail, string password)
        {
            var result = this.manager.Login(userEmail, password);
            if (result.Equals("LOGIN SUCCESS"))
            {
                return new ObjectResult(GenerateToken(userEmail));
            }
            else
            {
                return BadRequest();
            }
        }

        private string GenerateToken(string userName)
        {
            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                signingCredentials: new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
