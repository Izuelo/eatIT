using System.Collections.Generic;
using eatIT.Database.Dtos;

namespace eatIT.Services.Interfaces
{
    public interface ICityService
    {
        public List<CityDto> GetAllCities();
    }
}