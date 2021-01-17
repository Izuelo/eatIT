using System.Linq;
using eatIT.Database.Entity;
using eatIT.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eatIT.Database.Repository.Classes
{
    public class AuthRepository : BaseRepository<UserEntity>, IAuthRepository
    {
        

        public AuthRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            
        }
        
        
    }
}