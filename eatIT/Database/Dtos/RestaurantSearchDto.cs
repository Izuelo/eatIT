namespace eatIT.Database.Dtos
{
    public class RestaurantSearchDto
    {
        public int RestaurantEntityId { get; set; }
        public string Name { get; set; }
        
        public string Address { get; set; }

        public string Locality { get; set; }
        
        public string Thumbnail { get; set; }
        
        public string Rating { get; set; }
    }
}