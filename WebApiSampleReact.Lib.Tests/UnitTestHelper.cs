using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiSampleReact.Lib.Data;

namespace WebApiSampleReact.Lib.Tests
{
    public static class UnitTestHelper
    {

        public static CarDealershipContext CreateDbContext()
        {
            var builder = new DbContextOptionsBuilder<CarDealershipContext>();
            builder.UseInMemoryDatabase(databaseName: "CarDealershipDb");

            var carDealershipContext = new CarDealershipContext(new NullLoggerFactory(), GetInMemoryConfiguration());
            // Delete existing db before creating a new one
            carDealershipContext.Database.EnsureDeleted();
            carDealershipContext.Database.EnsureCreated();

            SeedDatabaseAsync(carDealershipContext).Wait();

            return carDealershipContext;
        }

        private static async Task SeedDatabaseAsync(CarDealershipContext context)
        {
            //plat-independent file
            var seedData = File.ReadAllText(Path.Combine(".", "Seed.json"));
            var seededCars = JsonSerializer.Deserialize<IEnumerable<CarEntity>>(seedData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Cars.AddRangeAsync(seededCars);

            var resultSaveCar = await context.SaveChangesAsync();
        }

        public static IConfiguration GetInMemoryConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();

            var inmemCollection = new Dictionary<string, string>();

            inmemCollection.Add("ConnectionStrings:MainConnection", "Server=.;Database=CarDealershipDb;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true;");

            var updatedConfig = configBuilder.AddInMemoryCollection(inmemCollection).Build();

            return updatedConfig;
        }
    }
}
