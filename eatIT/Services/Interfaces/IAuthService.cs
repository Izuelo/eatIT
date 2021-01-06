using System.Threading.Tasks;
using eatIT.Database.Entity;

namespace eatIT.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<UserEntity> Register(string username, string password); 
        public Task<UserEntity> Login(string username, string password);
        bool UserExists(string username);
    }
}