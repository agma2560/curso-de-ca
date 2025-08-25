using Jwt.Constants;
using Jwt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpPost]
        public IActionResult Login(UserDTO userDTO)
        {
            var user = Autenticate(userDTO);
            if(user != null)
            {
                // Crear Token
                var token = Generate(user);

                return Ok(token);
            }
            else
            {
                return NotFound("Usuario no encontrado");
            }
        }

        private User Autenticate(UserDTO userDTO)
        {
            var currentUser = UserDB.Users.FirstOrDefault(user 
                => user.UserName == userDTO.UserName.ToLower() 
                && user.Password == userDTO.Password.ToLower());
            if (currentUser != null)
            {
                return currentUser;
            }
            else
            {
                return null;
            }
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            // Crear los claims          
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.EmailAddess),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Rol),
                new Claim("IdEmpresa", "445")
            };

            // Crear el token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
