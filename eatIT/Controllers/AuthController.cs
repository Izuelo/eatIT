using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using eatIT.Database.Dtos;
using eatIT.Database.Entity;
using eatIT.Database.Repository.Interfaces;
using eatIT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace eatIT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        public AuthController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }
        
        [HttpPost("register")] //<host>/api/auth/register
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto){ //Data Transfer Object containing username and password.
            // validate request
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            userRegisterDto.Username = userRegisterDto.Username.ToLower(); //Convert username to lower case before storing in database.

            if( _authService.UserExists(userRegisterDto.Username)) 
                return BadRequest("Username is already taken");
            

            await _authService.Register(userRegisterDto.Username, userRegisterDto.Password);

            return StatusCode(201);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var userFromRepo = await _authService.Login(userLoginDto.Username.ToLower(), userLoginDto.Password);
            if (userFromRepo == null) //User login failed
                return Unauthorized();

            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,userFromRepo.UserEntityId.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { tokenString,userFromRepo.UserEntityId });
        }
    }
}