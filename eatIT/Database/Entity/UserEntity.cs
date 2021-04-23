using System.Collections.Generic;
using System.Dynamic;

namespace eatIT.Database.Entity
{
    public class UserEntity
    {
        public int UserEntityId { get; set; }
        public string Username { get; set; }
        
        public string Role { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        public ICollection<LikedRestaurantsEntity> Restaurants { get; set; }

        public ICollection<CommentEntity> Comments{ get; set; }
        
        public ICollection<LikedCommentsEntity> LikedComments{ get; set; }
    }
}