using System.Threading.Tasks;

namespace eatIT.Services.Interfaces
{
    public interface ISearchRestaurant
    {
        public Task GetRestaurantsFromQuery(string query);
        public Task GetCuisinesFromQuery(string query);
    }
}