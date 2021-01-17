using System.Threading.Tasks;
using eatIT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eatIT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController:ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values =  _cityService.GetAllCities();
            return Ok(values);
        }
    }
}