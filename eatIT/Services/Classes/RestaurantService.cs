using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eatIT.Database;
using eatIT.Database.Dtos;
using eatIT.Database.Entity;
using eatIT.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace eatIT.Services.Classes
{
    public class RestaurantService:IRestaurantService
    {
        private readonly DatabaseContext _databaseContext;

        public RestaurantService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public List<RestaurantEntity> GetRestaurantSearchResult(string cityName, string cuisine, int rating)
        {
            var restaurantList= _databaseContext.Restaurants
                .Where(r=>r.City.CityName==cityName && r.Cuisines.Any
                    (c=>c.CuisineEntity.CuisineName==cuisine)&&r.Rating>= rating)
                .ToList();
            return restaurantList;
        }

        public Task<RestaurantEntity> GetRestaurantById(int restaurantId)
        {
            var restaurant =
                _databaseContext.Restaurants.FirstOrDefaultAsync(r => r.RestaurantEntityId == restaurantId);
            return restaurant;
        }

        public List<RestaurantEntity> GetTopRestaurants(string cityName)
        {
            var restaurantList= _databaseContext.Restaurants.Where
                (r=>r.City.CityName==cityName).OrderByDescending(r => r.Rating)
                .Take(10).ToList();
            if (!restaurantList.Any())
            {
                throw new BadHttpRequestException("Restaurants not found. Please check if city name is correct");
            }
            return restaurantList;
        }
    }
}