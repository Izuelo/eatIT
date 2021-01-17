using System.Collections.Generic;

namespace eatIT.Database.Entity
{
    public class UserEntity
    {
        public int UserEntityId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        public ICollection<LikedRestaurantsEntity> Restaurants { get; set; }
    }
}