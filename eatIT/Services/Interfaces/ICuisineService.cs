using System.Collections.Generic;
using System.Threading.Tasks;
using eatIT.Database.Dtos;

namespace eatIT.Services.Interfaces
{
    public interface ICuisineService
    {
        public List<CuisineDto> GetAllCuisines();
    }
}