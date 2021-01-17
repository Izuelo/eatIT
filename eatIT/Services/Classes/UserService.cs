using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using eatIT.Database;
using eatIT.Database.Entity;
using eatIT.Database.Repository.Interfaces;
using eatIT.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace eatIT.Services.Classes
{
    public class UserService:IUserService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IBaseRepository<LikedRestaurantsEntity> _likRepository;

        public UserService(DatabaseContext databaseContext, IBaseRepository<LikedRestaurantsEntity> likRepository)
        {
            _databaseContext = databaseContext;
            _likRepository = likRepository;
        }
        
        public async Task<List<UserEntity>> GetAllUsers()
        {
            var userList  = await _databaseContext.Users.ToListAsync();
            return userList;
        }

        public async Task<UserEntity> GetUserById(int userId)
        {
            var user = await _databaseContext.Users.FirstOrDefaultAsync(x => x.UserEntityId == userId);
            return user;
        }

        public async Task<LikedRestaurantsEntity> AddToFav(int userEntityId, int restaurantEntityId)
        {
            if (_likRepository.Any(x => x.UserEntityId == userEntityId && x.RestaurantEntityId == restaurantEntityId))
            {
                throw new BadHttpRequestException("Already in favoruites");
            }


            return await _likRepository.Add(new LikedRestaurantsEntity()
            {
                UserEntityId = userEntityId,
                RestaurantEntityId = restaurantEntityId
            });

        }

        public  List<LikedRestaurantsEntity> GetAllFav(int userEntityId)
        {
            var favList = _databaseContext.LikedRestaurant.Where(x => x.UserEntityId == userEntityId).ToList();

            return favList;
        }

        public  bool CheckIfFav(int userEntityId, int restaurantEntityId)
        {
            return _likRepository.Any(x => x.UserEntityId == userEntityId && x.RestaurantEntityId == restaurantEntityId);
        }
        
        public LikedRestaurantsEntity DeleteFromFav(int userEntityId, int restaurantEntityId)
        {
            if (!_likRepository.Any(x => x.UserEntityId == userEntityId && x.RestaurantEntityId == restaurantEntityId))
            {
                throw new BadHttpRequestException("No match found");
            }


            return  _likRepository.Delete(new LikedRestaurantsEntity()
            {
                UserEntityId = userEntityId,
                RestaurantEntityId = restaurantEntityId
            });

        }

        public List<RestaurantEntity> GetUserFavourites(int userId)
        {
            var userFavourites = _databaseContext.Restaurants
                .Where(r => r.Users.Any(l => l.UserEntity.UserEntityId == userId)).ToList();
            return userFavourites;
        }
    }
}