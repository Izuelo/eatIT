using System;
using System.Threading.Tasks;
using eatIT.Database;
using eatIT.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eatIT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var userList = await _userService.GetAllUsers();
            return Ok(userList);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int userId)
        {
            var value = await _userService.GetUserById(userId);
            return Ok(value);
        }

        [HttpPost("addfav")]
        public async Task<IActionResult> AddToFav(int userEntityId, int restaurantEntityId)
        {
            try
            {
                await _userService.AddToFav(userEntityId, restaurantEntityId);
            }
            catch (BadHttpRequestException e)
            {   
                Console.WriteLine(e);
                return BadRequest("Already added to favourites");
            }

            return Ok();
        }
        
        [HttpGet("getallfav")]
        public IActionResult GetAllFav(int userEntityId)
        {
            var value =  _userService.GetAllFav(userEntityId);
            return Ok(value);
        }

        [HttpGet("checkfav")]
        public IActionResult CheckFav(int userEntityId, int restaurantEntityId)
        {
            var isFav = _userService.CheckIfFav(userEntityId, restaurantEntityId);
            return Ok(isFav);
        }

        [HttpPost("delfav")]
        public IActionResult DeleteFromFav(int userEntityId, int restaurantEntityId)
        {
            var value= _userService.DeleteFromFav(userEntityId, restaurantEntityId);
            return Ok(value);
        }

        [HttpGet("getuserfav")]
        public IActionResult GetUserFavourites(int userEntityId)
        {
            var userFavourites = _userService.GetUserFavourites(userEntityId);
            return Ok(userFavourites);
        }
        
    }
}