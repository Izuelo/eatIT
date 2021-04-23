using System;
using System.Collections.Generic;

namespace eatIT.Database.Entity
{
    public class CommentEntity
    {
        public int CommentEntityId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int PositiveScore { get; set; }
        public int NegativeScore { get; set; }
        
        public int UserEntityId { get; set; }
        public UserEntity UserEntity { get; set; }
        
        public int RestaurantEntityId { get; set; }
        public RestaurantEntity RestaurantEntity { get; set; }
        
        public ICollection<LikedCommentsEntity> LikedComments{ get; set; }
    }
}