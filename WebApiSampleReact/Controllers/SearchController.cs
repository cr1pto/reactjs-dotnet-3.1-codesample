using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSampleReact.Lib.Data;

namespace WebApiSampleReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly CarDealershipContext _carDealershipContext;

        public SearchController(CarDealershipContext carDealershipContext)
        {
            _carDealershipContext = carDealershipContext;
        }

        [HttpGet]
        [Route("colors")]
        public async Task<IEnumerable<string>> GetByColor()
        {
            var data = await _carDealershipContext.Cars
                .ToArrayAsync();

            return data.Select(s => s.Color).Distinct();
        }

        [HttpGet]
        [Route("makes")]
        public async Task<IEnumerable<string>> GetByMake()
        {
            var data = await _carDealershipContext.Cars
                .ToArrayAsync();

            return data.Select(s => s.Make).Distinct();
        }
    }
}
