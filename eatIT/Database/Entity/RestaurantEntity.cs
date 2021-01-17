using System.Collections.Generic;

namespace eatIT.Database.Entity
{
    public class RestaurantEntity
    {
        public int RestaurantEntityId { get; set; }
        public string Name { get; set; }


        public string Address { get; set; }

        public string Locality { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string OpenHours { get; set; }

        public string Thumbnail { get; set; }

        public string FeaturedIMG { get; set; }
        public float Rating { get; set; }

        public string RatingText { get; set; }

        public int Votes { get; set; }

        public int CityEntityId { get; set; }

        public CityEntity City { get; set; }

        public ICollection<RestaurantCuisinesEntity> Cuisines { get; set; }
        
        public ICollection<LikedRestaurantsEntity> Users { get; set; }


        public RestaurantEntity(int restaurantEntityId, string name, string address, string locality, string latitude,
            string longitude, string openHours, string thumbnail, string featuredImg, float rating, string ratingText,
            int votes, int cityEntityId)
        {
            RestaurantEntityId = restaurantEntityId;
            Name = name;
            Address = address;
            Locality = locality;
            Latitude = latitude;
            Longitude = longitude;
            OpenHours = openHours;
            Thumbnail = thumbnail;
            FeaturedIMG = featuredImg;
            Rating = rating;
            RatingText = ratingText;
            Votes = votes;
            CityEntityId = cityEntityId;
        }

        public RestaurantEntity()
        {
        }
    }
}