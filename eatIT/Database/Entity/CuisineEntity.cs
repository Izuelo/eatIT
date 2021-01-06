using System.Collections.Generic;

namespace eatIT.Database.Entity
{
    public class CuisineEntity
    {
        public int CuisineEntityId { get; set; }
        public string CuisineName { get; set; }
        
        public ICollection<RestaurantCuisinesEntity> Restaurants { get; set; }
    }
}