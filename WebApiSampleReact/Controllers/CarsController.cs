using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiSampleReact.Lib;
using WebApiSampleReact.Lib.Data;

namespace WebApiSampleReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CarsController : ControllerBase
    {
        private readonly ICarDealershipService _carDealershipService;

        public CarsController(ICarDealershipService carDealershipService)
        {
            _carDealershipService = carDealershipService;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public async Task<IEnumerable<CarEntity>> Get(CancellationToken cancellationToken)
        {
            return await _carDealershipService.GetCars(cancellationToken);
        }

        //[HttpGet]
        //[Route("with/4wd")]
        //public async Task<IEnumerable<CarEntity>> GetAllWith4wd()
        //{
        //    var data = await _carDealershipContext.Cars
        //        .Where(car => car.IsFourWheelDrive)
        //        .ToArrayAsync();

        //    return data;
        //}

        //[HttpGet]
        //[Route("with/heatedseats")]
        //public async Task<IEnumerable<CarEntity>> GetAllWithHeatedSeats()
        //{
        //    var data = await _carDealershipContext.Cars
        //        .Where(car => car.HasHeatedSeats)
        //        .ToArrayAsync();

        //    return data;
        //}

        //[HttpGet]
        //[Route("with/lowmiles")]
        //public async Task<IEnumerable<CarEntity>> GetAllWithLowMiles()
        //{
        //    var data = await _carDealershipContext.Cars
        //        .Where(car => car.HasLowMiles)
        //        .ToArrayAsync();

        //    return data;
        //}

        //[HttpGet]
        //[Route("with/navigation")]
        //public async Task<IEnumerable<CarEntity>> GetAllWithNavigation()
        //{
        //    var data = await _carDealershipContext.Cars
        //        .Where(car => car.HasNavigation)
        //        .ToArrayAsync();

        //    return data;
        //}

        //[HttpGet]
        //[Route("with/powerwindows")]
        //public async Task<IEnumerable<CarEntity>> GetAllWithPowerWindows()
        //{
        //    var data = await _carDealershipContext.Cars
        //        .Where(car => car.HasPowerWindows)
        //        .ToArrayAsync();

        //    return data;
        //}

        //[HttpGet]
        //[Route("with/sunroof")]
        //public async Task<IEnumerable<CarEntity>> GetAllWithSunroof()
        //{
        //    var data = await _carDealershipContext.Cars
        //        .Where(car => car.HasSunroof)
        //        .ToArrayAsync();

        //    return data;
        //}
    }
}
