using System.Threading.Tasks;
using eatIT.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eatIT.Controllers
{
    [Route("api/[controller]")]
    public class ApiController :ControllerBase
    {
        private readonly ISearchRestaurant _searchRestaurant;

        public ApiController(ISearchRestaurant searchRestaurant)
        {
            _searchRestaurant = searchRestaurant;
        }

        [HttpGet("restaurants")]
        public async Task<IActionResult> Restaurants()
        {
            await _searchRestaurant.GetRestaurantsFromQuery("");

            return Ok();
        }
        
        [HttpGet("cuisines")]
        public async Task<IActionResult> GetCuisines()
        {
            await _searchRestaurant.GetCuisinesFromQuery("");

            return Ok();
        }
    }
}