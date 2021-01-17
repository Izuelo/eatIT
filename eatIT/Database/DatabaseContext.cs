using eatIT.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace eatIT.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantCuisinesEntity>().HasKey(rc => new { rc.CuisineEntityId, rc.RestaurantEntityId });
            modelBuilder.Entity<LikedRestaurantsEntity>().HasKey(ur => new { ur.UserEntityId, ur.RestaurantEntityId });
        }
        
        public DbSet<RestaurantEntity> Restaurants { get; set; }
        public DbSet<CuisineEntity> Cuisines { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<RestaurantCuisinesEntity> RestaurantCuisines { get; set; }
        public DbSet<LikedRestaurantsEntity> LikedRestaurant { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
