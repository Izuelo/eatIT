using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eatIT.Database;
using eatIT.Database.Dtos;
using eatIT.Services.Interfaces;

namespace eatIT.Services.Classes
{
    public class CuisineService:ICuisineService
    {
        private readonly DatabaseContext _dbContext;

        public CuisineService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public List<CuisineDto> GetAllCuisines()
        {
            var cuisines =  _dbContext.Cuisines.Select(c => new CuisineDto(){
                CuisineEntityId = c.CuisineEntityId ,
                CuisineName = c.CuisineName
            }).ToList();
            
            return cuisines;
        }
    }
}