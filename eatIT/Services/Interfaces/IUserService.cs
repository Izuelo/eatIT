using System.Collections.Generic;
using System.Threading.Tasks;
using eatIT.Database.Entity;

namespace eatIT.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserEntity>> GetAllUsers();
        public Task<UserEntity> GetUserById(int userId);
        public Task<LikedRestaurantsEntity> AddToFav(int userEntityId, int restaurantEntityId);
        public List<LikedRestaurantsEntity> GetAllFav(int userEntityId);
        public bool CheckIfFav(int userEntityId, int restaurantEntityId);
        public LikedRestaurantsEntity DeleteFromFav(int userEntityId, int restaurantEntityId);
        public List<RestaurantEntity> GetUserFavourites(int userId);
    }
}