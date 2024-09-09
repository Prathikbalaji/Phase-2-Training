﻿using APIminiproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIminiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly SymmetricSecurityKey _key;
        private readonly CustomerDBContext _con;

        public TokenController(IConfiguration configuration, CustomerDBContext con)
        {
            _key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(configuration["Key"]!));
            _con = con;
        }

        [HttpPost]
        public string GenerateToken(User user)
        {
            string token = string.Empty;


            if (ValidateUser(user.Email, user.Password, user.Role))
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role!)
                };

                var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
                var tokenDescription = new SecurityTokenDescriptor
                {
                    SigningCredentials = cred,
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddMinutes(20)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createToken = tokenHandler.CreateToken(tokenDescription);
                token = tokenHandler.WriteToken(createToken);
            }
            else
            {
                return string.Empty;
            }

            return token;
        }

        private bool ValidateUser(string email, string password, string requiredRole)
        {
            var user = _con.users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user != null && user.Role == requiredRole;
        }
    }
}
