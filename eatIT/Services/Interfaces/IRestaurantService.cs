using System.Collections.Generic;
using System.Threading.Tasks;
using eatIT.Database.Dtos;
using eatIT.Database.Entity;

namespace eatIT.Services.Interfaces
{
    public interface IRestaurantService
    {
        public List<RestaurantEntity> GetRestaurantSearchResult(string cityName, string cuisine, int rating);
        public Task<RestaurantEntity> GetRestaurantById(int restaurantId);
    }
}