namespace eatIT.Database.Entity
{
    public class LikedCommentsEntity
    {
        public int UserEntityId { get; set; }
        public UserEntity UserEntity { get; set; }
        
        public int CommentEntityId { get; set; }
        public CommentEntity CommentEntity { get; set; }
    }
}