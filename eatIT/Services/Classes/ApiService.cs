using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using eatIT.Database.Dtos;
using eatIT.Database.Entity;
using eatIT.Database.Repository.Interfaces;
using eatIT.Services.Interfaces;

namespace eatIT.Services.Classes
{
    public class SearchRestaurant : ISearchRestaurant
    {
        private readonly HttpClient _httpClient;
        private readonly IBaseRepository<RestaurantEntity> _restaurantRepository;
        private readonly IBaseRepository<CuisineEntity> _cuisineRepository;
        private readonly IBaseRepository<RestaurantCuisinesEntity> _joinedTableRepository;
        private const string BaseUrl = "https://developers.zomato.com/api/v2.1/search";
        private const string ApiKey = "a183848c332be9083a6271f3a821e9f2";

        public SearchRestaurant(HttpClient httpClient, IBaseRepository<RestaurantEntity> restaurantRepository, IBaseRepository<CuisineEntity> cuisineRepository, IBaseRepository<RestaurantCuisinesEntity> joinedTableRepository)
        {
            _httpClient = httpClient;
            _restaurantRepository = restaurantRepository;
            _cuisineRepository = cuisineRepository;
            _joinedTableRepository = joinedTableRepository;
        }

        public async Task GetRestaurantsFromQuery(string query)
        {
            _httpClient.DefaultRequestHeaders.Add("user-key", ApiKey);
            for (int spoint = 0; spoint < 150; spoint++)
            {
                var response = await _httpClient.GetStringAsync(
                    $"{BaseUrl}?entity_id=109&entity_type=city&start={spoint}&count=1");

                var searchResult = JsonSerializer.Deserialize<ApiResponse>(response);
            
                if (searchResult?.restaurants != null)
                {
                    var restaurant= searchResult.restaurants.Select(x => new RestaurantEntity(
                        Convert.ToInt32( x.restaurant.id),
                        x.restaurant.name,
                        x.restaurant.location.address,
                        x.restaurant.location.locality,
                        x.restaurant.location.latitude,
                        x.restaurant.location.longitude,
                        x.restaurant.timings,
                        x.restaurant.thumb,
                        x.restaurant.featured_image,
                        x.restaurant.user_rating.aggregate_rating,
                        x.restaurant.user_rating.rating_text,
                        x.restaurant.user_rating.votes,
                        x.restaurant.location.city_id
                    ));
                    if(!_restaurantRepository.Any(x=>x.RestaurantEntityId==restaurant.First().RestaurantEntityId))
                    {
                        List<string> cuisines = new List<string>();
                        var cuisinesApi= searchResult.restaurants.Select(x =>new string(x.restaurant.cuisines));
                    
                        foreach (var cuisinesStr in cuisinesApi)
                        {
                            var splitCuisines = cuisinesStr.Split(",",StringSplitOptions.TrimEntries);
                            cuisines.AddRange(splitCuisines);
                        }
                        foreach (var restaurantEntity in restaurant)
                        {
                            await _restaurantRepository.Add(restaurantEntity);
                        }

                        foreach (var cuisine in cuisines)
                        {
                            var cuisineDb= _cuisineRepository.GetByParam(x => x.CuisineName == cuisine);
                            var joinedTableEntry = new RestaurantCuisinesEntity()
                            {
                                CuisineEntityId  = cuisineDb.CuisineEntityId,
                                RestaurantEntityId = restaurant.First().RestaurantEntityId
                            
                            };
                            await _joinedTableRepository.Add(joinedTableEntry);
                            
                        }
                    }
                    
                } 
            }
            
        }

        public async Task GetCuisinesFromQuery(string query)
        {
            _httpClient.DefaultRequestHeaders.Add("user-key", ApiKey);
            for (int spoint = 0; spoint < 4000; spoint+=20)
            {
                var response = await _httpClient.GetStringAsync(
                    $"{BaseUrl}?entity_id=109&entity_type=city&start={spoint}");

                var searchResult = JsonSerializer.Deserialize<ApiResponse>(response);

                if (searchResult?.restaurants != null)
                {
                    List<string> cuisines = new List<string>();
                    var cuisinesApi= searchResult.restaurants.Select(x =>new string(x.restaurant.cuisines));

                    foreach (var cuisinesStr in cuisinesApi)
                    {
                        var splitCuisines = cuisinesStr.Split(",",StringSplitOptions.TrimEntries);
                        cuisines.AddRange(splitCuisines);
                    }

                    foreach (var newCuisine in from cuisine in cuisines where !_cuisineRepository.Any(x=>x.CuisineName==cuisine) select new CuisineEntity(){CuisineName = cuisine})
                    {
                        await _cuisineRepository.Add(newCuisine);
                    }
                }
            }
           
        }
    }
}