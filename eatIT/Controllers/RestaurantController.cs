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
            var values = _restaurantService.GetRestaurantSearchResult(cityName, cuisine, rating);
            return Ok(values);
        }
        
        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> GetRestaurantById( int restaurantId)
        {
            var values = await _restaurantService.GetRestaurantById(restaurantId);
            return Ok(values);
        }
    }
}