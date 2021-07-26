using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiSampleReact.Lib.Data;
using Xunit;

namespace WebApiSampleReact.Lib.Tests
{
    public class CarDealershipServiceTests : IDisposable
    {
        private CarDealershipContext _dbContext;
        private ICarDealershipService _service;

        public CarDealershipServiceTests()
        {
            _dbContext = UnitTestHelper.CreateDbContext();
            _service = new CarDealershipService(_dbContext);
        }

        [Fact]
        public async Task HappyPath_GetCars()
        {
            var cars = await _service.GetCars(CancellationToken.None);

            Assert.NotEmpty(cars);
            Assert.NotNull(cars.First());
            Assert.Equal("Silver", cars.First().Color);
        }

        [Fact]
        public async Task HappyPath_GetColors()
        {
            var colors = await _service.GetCarColors(CancellationToken.None);

            Assert.NotEmpty(colors);
            Assert.Equal("Silver", colors.First());
        }

        [Fact]
        public async Task HappyPath_GetMakes()
        {
            var makes = await _service.GetCarMakes(CancellationToken.None);

            Assert.NotEmpty(makes);
            Assert.Equal("Toyota", makes.First());
        }

        public void Dispose()
        {
            ((IDisposable)_dbContext).Dispose();
        }
    }
}
