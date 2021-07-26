using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApiSampleReact.Lib.Data;

namespace WebApiSampleReact.Lib
{
    public interface ICarDealershipService
    {
        Task<IEnumerable<CarEntity>> GetCars(CancellationToken cancellationToken);
        Task<IEnumerable<string>> GetCarColors(CancellationToken cancellationToken);
        Task<IEnumerable<string>> GetCarMakes(CancellationToken cancellationToken);
    }
}