using Waniel.Domains;

namespace Waniel.Services
{
    public class GoogleService : IMapService
    {
        public async Task<double> GetDistance(ICoordinate from, ICoordinate to)
        {
            //we can use online 3-rd party apps like Distance Matrix Api from Google or etc. but because its a test project I prefer to do it by local codes.
            throw new NotImplementedException();
        }
    }
}
