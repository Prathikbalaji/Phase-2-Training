using APIdemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        //private readonly SymmetricSecurityKey _key;
        //private readonly EmployeeDBContext _con;
        //public TokenController(IConfiguration configuration, EmployeeDBContext con)
        //{
        //    _key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(configuration["Key"]!));
        //    _con = con;
        //}
        //[HttpPost]
        //public string GenerateToken(User user)
        //{
        //    string token = string.Empty;
        //    if (ValidateUser(user.Email, user.Password))
        //    {
        //        var claims = new List<Claim>
        //          {
        //              new Claim(JwtRegisteredClaimNames.NameId,user.UserName!),
        //              new Claim(JwtRegisteredClaimNames.Email,user.Email)

        //          };
        //        var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
        //        var tokenDescription = new SecurityTokenDescriptor
        //        {
        //            SigningCredentials = cred,
        //            Subject = new ClaimsIdentity(claims),
        //            Expires = DateTime.Now.AddMinutes(2)
        //        };
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var createToken = tokenHandler.CreateToken(tokenDescription);
        //        token = tokenHandler.WriteToken(createToken);
        //        return token;
        //    }
        //    else
        //    {
        //        return string.Empty;
        //    }
        //}
        //private bool ValidateUser(string email, string password)
        //{
        //    var users = _con.users.ToList();
        //    var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
        //    if (user != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        private readonly SymmetricSecurityKey _key;
        private readonly EmployeeDBContext _con;

        public TokenController(IConfiguration configuration, EmployeeDBContext con)
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
                        Expires = DateTime.Now.AddMinutes(2)
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
