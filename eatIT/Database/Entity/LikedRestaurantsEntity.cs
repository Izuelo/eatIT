namespace eatIT.Database.Entity
{
    public class LikedRestaurantsEntity
    {
        public int UserEntityId { get; set; }
        public UserEntity UserEntity { get; set; }
        
        public int RestaurantEntityId { get; set; }
        public RestaurantEntity RestaurantEntity { get; set; }
    }
}