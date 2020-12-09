using System.Threading.Tasks;
using eatIT.Entity;

namespace eatIT.Repository
{
    public interface IAuthRepository
    {
        Task<UserEntity> Register(UserEntity user, string password); 
        Task<UserEntity> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}