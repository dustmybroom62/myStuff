
using Microsoft.EntityFrameworkCore;

namespace MyApp.Models {
    class sakilaContextFactory {
        public static sakilaContext Create(string connectionString) {
            var optionsBuilder = new DbContextOptionsBuilder<sakilaContext>();
            optionsBuilder.UseMySQL(connectionString);
            var context = new sakilaContext(optionsBuilder.Options);
            return context;
        }
    }
}