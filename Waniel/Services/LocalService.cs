using Waniel.Domains;

namespace Waniel.Services
{
    public class LocalService : IMapService
    {
        public async Task<double> GetDistance(ICoordinate from, ICoordinate to)
        {
            double fromLat = Math.PI * from.Lat / 180;
            double toLat = Math.PI * to.Lat / 180;

            double theta = from.Lon - to.Lon;
            double rtheta = Math.PI * theta / 180;

            double distInMiles =
                Math.Sin(fromLat) * Math.Sin(toLat) + Math.Cos(fromLat) *
                Math.Cos(toLat) * Math.Cos(rtheta);

            distInMiles = Math.Acos(distInMiles);
            distInMiles = distInMiles * 180 / Math.PI;
            distInMiles = distInMiles * 60 * 1.1515;

            return distInMiles;

        }
    }
}
