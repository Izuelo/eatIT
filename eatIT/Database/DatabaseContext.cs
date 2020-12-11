using eatIT.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace eatIT.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        private DbSet<WeatherForecast> Forecasts { get; set; }
        
        public DbSet<UserEntity> Users { get; set; }
    }
}