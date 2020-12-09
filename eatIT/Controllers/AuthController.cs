using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using eatIT.Dtos;
using eatIT.Entity;
using eatIT.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace eatIT.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }
        
        [HttpPost("register")] //<host>/api/auth/register
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto){ //Data Transfer Object containing username and password.
            // validate request
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            userRegisterDto.Username = userRegisterDto.Username.ToLower(); //Convert username to lower case before storing in database.

            if(await _repo.UserExists(userRegisterDto.Username)) 
                return BadRequest("Username is already taken");

            var userToCreate = new UserEntity{
                Username = userRegisterDto.Username
            };

            var createUser = await _repo.Register(userToCreate, userRegisterDto.Password);

            return StatusCode(201);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var userFromRepo = await _repo.Login(userLoginDto.Username.ToLower(), userLoginDto.Password);
            if (userFromRepo == null) //User login failed
                return Unauthorized();

            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { tokenString });
        }
    }
}