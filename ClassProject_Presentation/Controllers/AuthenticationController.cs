using Application.Services;
using ClassProject_Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClassProject_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserService userService, IConfiguration config)
        {
            _userService = userService;
            _configuration = config;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticationCredentials authenticationRequest)
        {
            Domain.Entities.User? user = _userService.GetByUser(authenticationRequest.Username);
            if( user != null && authenticationRequest.Password == user.Password)
            {
                //Paso 2: Crear el token
                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Auth:SaltForJWT"]));
                //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

                var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                //Los claims son datos en clave->valor que nos permite guardar data del usuario.
                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", user.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
                claimsForToken.Add(new Claim("given_name", user.Name)); //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app
                claimsForToken.Add(new Claim("role", user.Role)); //Debería venir del usuario

                var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
                  _configuration["Auth:Issuer"],
                   _configuration["Auth:Audience"],
                  claimsForToken,
                  DateTime.UtcNow,
                  DateTime.UtcNow.AddHours(1),
                  credentials);

                var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                    .WriteToken(jwtSecurityToken);

                return Ok(tokenToReturn.ToString());
            }
            return NotFound();
        }
    }
}
