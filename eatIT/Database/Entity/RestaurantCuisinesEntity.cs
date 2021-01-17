using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace eatIT.Database.Entity
{
    
    public class RestaurantCuisinesEntity
    {
        public int CuisineEntityId { get; set; }
        public CuisineEntity CuisineEntity { get; set; }
        
        public int RestaurantEntityId { get; set; }
        public RestaurantEntity RestaurantEntity { get; set; }
    }
}