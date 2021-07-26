using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiSampleReact.Lib.Data;

namespace WebApiSampleReact.Lib
{
    public class CarDealershipService : ICarDealershipService
    {
        private readonly CarDealershipContext _context;

        public CarDealershipService(CarDealershipContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarEntity>> GetCars(CancellationToken cancellationToken)
        {
            return await _context.Cars.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<string>> GetCarColors(CancellationToken cancellationToken)
        {
            var data = await _context.Cars
               .ToArrayAsync(cancellationToken);

            return data.Select(s => s.Color).Distinct();
        }

        public async Task<IEnumerable<string>> GetCarMakes(CancellationToken cancellationToken)
        {
            var data = await _context.Cars
                .ToArrayAsync(cancellationToken);

            return data.Select(s => s.Make).Distinct();
        }
    }
}
