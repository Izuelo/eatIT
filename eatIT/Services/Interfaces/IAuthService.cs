using eatIT.Database.Entity;

namespace eatIT.Services.Interfaces
{
    public interface IAuthService
    {
        UserEntity Register(UserEntity user, string password); 
        UserEntity Login(string username, string password);
        bool UserExists(string username);
    }
}