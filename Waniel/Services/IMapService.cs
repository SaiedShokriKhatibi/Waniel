using Waniel.Domains;

namespace Waniel.Services
{
    public interface IMapService
    {
        Task<double> GetDistance(ICoordinate from, ICoordinate to);
    }
}
