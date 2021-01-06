using System.Collections.Generic;
using System.Linq;
using eatIT.Database;
using eatIT.Database.Dtos;
using eatIT.Services.Interfaces;

namespace eatIT.Services.Classes
{
    public class CityService:ICityService
    {
        private readonly DatabaseContext _dbContext;

        public CityService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CityDto> GetAllCities()
        {
            var cities =  _dbContext.Cities.Select(c => new CityDto(){
                CityId = c.Id ,
                CityName = c.City
            }).ToList();
            
            return cities;
        }
    }
}