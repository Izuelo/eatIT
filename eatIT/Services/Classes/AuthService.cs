
using eatIT.Database.Entity;
using eatIT.Database.Repository.Interfaces;
using eatIT.Services.Interfaces;

namespace eatIT.Services.Classes
{
    public class AuthService:IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public  UserEntity Login(string username, string password)
        {
            var user =  _authRepository.GetByParam(x => x.Username == username); //Get user from database.
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

        public  UserEntity Register(UserEntity user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _authRepository.Add(user); // Adding the user to context of users.
           

            return user;
        }
        
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public  bool UserExists(string username)
        {
            return _authRepository.Any(x => x.Username == username);
        }
    }
}