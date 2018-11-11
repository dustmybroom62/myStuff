using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WorldWebServer.Models {
    public class WorldDbContext : DbContext {
        public WorldDbContext(DbContextOptions<WorldDbContext> options)
        : base(options) { }

        public virtual DbSet<Country> Country {get; set;}
        public virtual DbSet<City> City {get; set;}
    }

    class WorldDbContextFactory {
        public static WorldDbContext Create() {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets("GlobalCityManager_1234")
                .AddEnvironmentVariables()
                .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<WorldDbContext>();
            optionsBuilder.UseMySQL(connectionString);
            var dbContext = new WorldDbContext(optionsBuilder.Options);
            return dbContext;
        }
    }

}