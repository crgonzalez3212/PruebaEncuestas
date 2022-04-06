using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PruebaEncuestas.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaEncuestas.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration config)
        {
            _configuration = config;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserLogin request)
        {
            if (IsValid(request))
            {
                var token = GenerateToken();
                return Ok(new { token });
            }

            return NotFound();
        }

        private bool IsValid(UserLogin request)
        {
            //TODO validar usuario 
            return true;
        }

        private string GenerateToken()
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);
                       
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,"UserToken"),
                new Claim(ClaimTypes.Email,"UserToken@mail.com"),
                new Claim(ClaimTypes.Role,"Admin")
            };

            var payload = new JwtPayload(_configuration["Authentication:Issuer"], _configuration["Authentication:Audience"], claims, DateTime.Now, DateTime.Now.AddMinutes(20));
            var token =new  JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
