using System.Threading.Tasks;
using eatIT.Entity;
using Microsoft.EntityFrameworkCore;

namespace eatIT.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DatabaseContext _databaseContext;

        public AuthRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public async Task<UserEntity> Login(string username, string password)
        {
            var user = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Username == username); //Get user from database.
            if(user == null)
                return null; // User does not exist.

            if(!VerifyPassword(password, user.PasswordHash,user.PasswordSalt))
                return null;
            
            return user;
        }
        
        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){ 
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); // Create hash using password salt.
                for (int i = 0; i < computedHash.Length; i++){ // Loop through the byte array
                    if(computedHash[i] != passwordHash[i]) return false; // if mismatch
                }    
            }
            return true; //if no mismatches.
        }

        public async Task<UserEntity> Register(UserEntity user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _databaseContext.Users.AddAsync(user); // Adding the user to context of users.
            await _databaseContext.SaveChangesAsync(); // Save changes to database.

            return user;
        }
        
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _databaseContext.Users.AnyAsync(x => x.Username == username))
                return true;
            return false;
        }
    }
}