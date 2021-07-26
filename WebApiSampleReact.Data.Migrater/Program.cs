using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApiSampleReact.Data.Migrater
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            InitLogging();
            var builder = CreateHostBuilder(args).Build();
            var logger = builder.Services.GetService<ILogger<Program>>();

            logger.LogInformation("Starting migrations...");
            try
            {
                var context = builder.Services.GetService<CarDealershipContext>();

                await context.Database.MigrateAsync();

                await SeedDatabaseAsync(context, logger);

                logger.LogInformation("Migrations completed...");

                await builder.RunAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Migrations failed...");
            }
        }

        private static void InitLogging()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
        }

        private static async Task SeedDatabaseAsync(CarDealershipContext context, Microsoft.Extensions.Logging.ILogger logger)
        {
            //plat-independent file
            var seedData = File.ReadAllText(Path.Combine(".", "Seed.json"));
            var seededCars = JsonSerializer.Deserialize<IEnumerable<CarEntity>>(seedData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var existingCar = await context.Cars.FirstOrDefaultAsync();

            if (existingCar != null)
                return;

            await context.Cars.AddRangeAsync(seededCars);

            var resultSaveCar = await context.SaveChangesAsync();

            logger.LogInformation("Database operation results Save Operation: {1}:", resultSaveCar);
        }

        // EF Core uses this method at design time to access the DbContext
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.ConfigureKestrel(opts => {
                    opts.ListenAnyIP(5006);
                });
            });
    }
}
