using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;

namespace WebApiSampleReact.Lib.Data
{
    public class CarDealershipContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IConfiguration _configuration;

        public CarDealershipContext(ILoggerFactory loggerFactory,
            IConfiguration configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MainConnection"),
                options =>
                {
                    options.EnableRetryOnFailure(3, TimeSpan.FromMilliseconds(50), null);
                    options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) => BuildCarDealershipDbContext(modelBuilder);

        private void BuildCarDealershipDbContext(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEntity>(entity =>
            {
                entity.HasIndex(et => et._id)
                    .IncludeProperties(p => new
                    {
                        p.Year,
                        p.Price,
                        p.Make,
                        p.IsFourWheelDrive,
                        p.HasSunroof,
                        p.HasPowerWindows,
                        p.HasNavigation,
                        p.HasLowMiles,
                        p.HasHeatedSeats,
                        p.Color
                    });

                entity.Property(et => et.Year)
                    .HasMaxLength(150)
                    .HasColumnType("nvarchar");

                entity.Property(et => et.Price)
                    .HasMaxLength(150)
                    .HasColumnType("decimal(10,2)");

                entity.Property(et => et.Make)
                    .HasMaxLength(150)
                    .HasColumnType("nvarchar");

                entity.Property(et => et.Color)
                    .HasMaxLength(150)
                    .HasColumnType("nvarchar");

                entity.Property(et => et.HasHeatedSeats)
                    .HasColumnType("bit");

                entity.Property(et => et.HasLowMiles)
                    .HasColumnType("bit");

                entity.Property(et => et.HasNavigation)
                    .HasColumnType("bit");

                entity.Property(et => et.HasPowerWindows)
                    .HasColumnType("bit");

                entity.Property(et => et.HasSunroof)
                    .HasColumnType("bit");

                entity.Property(et => et.IsFourWheelDrive)
                    .HasColumnType("bit");
            });
        }

        public DbSet<CarEntity> Cars { get; set; }
    }
}
