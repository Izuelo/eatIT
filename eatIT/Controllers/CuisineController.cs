using System.Threading.Tasks;
using eatIT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eatIT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuisineController:ControllerBase
    {
        
        private readonly ICuisineService _cuisineService;

        public CuisineController(ICuisineService cuisineService)
        {
            _cuisineService = cuisineService;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values =  _cuisineService.GetAllCuisines();
            return Ok(values);
        }
    }
}