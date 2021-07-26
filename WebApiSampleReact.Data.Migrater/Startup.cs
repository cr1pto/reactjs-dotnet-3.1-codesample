using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiSampleReact.Data.Migrater
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            AddServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<CarDealershipContext>();
            services.AddSingleton((opts) => GetConfiguration());
        }

        private static IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            return configurationBuilder.AddJsonFile("appsettings.json").Build();
        }
    }
}
