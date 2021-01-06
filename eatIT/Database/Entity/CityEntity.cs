

using System.Collections.Generic;

namespace eatIT.Database.Entity
{
    public class CityEntity
    {

        public int Id { get; set; }
        public string City { get; set; }
        
        public ICollection<RestaurantEntity> Restaurants { get; set; }

        public CityEntity(int id, string city)
        {
            Id = id;
            City = city;
        }
        
    }
}