using Waniel.Domains;

namespace Waniel.Services
{
    public class DotNetService : IMapService
    {
        public async Task<double> GetDistance(ICoordinate from, ICoordinate to)
        {
            var fromCoord = new GeoCoordinatePortable.GeoCoordinate(from.Lat, from.Lon);
            var toCoord = new GeoCoordinatePortable.GeoCoordinate(to.Lat, to.Lon);

            var result = fromCoord.GetDistanceTo(toCoord) / 0.000621371;
            return result;
        }
    }
}
