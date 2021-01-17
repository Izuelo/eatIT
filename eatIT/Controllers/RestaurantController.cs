using System.Threading.Tasks;
using eatIT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eatIT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController:ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        
        [HttpGet]
        public IActionResult GetRestaurantList(string cityName, string cuisine, int rating)
        {
            var searchResult = _restaurantService.GetRestaurantSearchResult(cityName, cuisine, rating);
            return Ok(searchResult);
        }
        
        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> GetRestaurantById( int restaurantId)
        {
            var restaurantById = await _restaurantService.GetRestaurantById(restaurantId);
            return Ok(restaurantById);
        }
        
        [HttpGet("top")]
        public IActionResult GetTopRestaurants(string cityName)
        {
            var topRestaurants = _restaurantService.GetTopRestaurants(cityName);
            return Ok(topRestaurants);
        }
    }
}