

using System.Collections.Generic;

namespace eatIT.Database.Entity
{
    public class CityEntity
    {

        public int CityEntityId { get; set; }
        public string CityName { get; set; }
        
        public ICollection<RestaurantEntity> Restaurants { get; set; }
        
        
    }
}