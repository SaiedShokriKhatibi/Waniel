using Waniel.Domains;

namespace Waniel.Services
{
    public interface IPlaceService
    {
        Task<IPlace> GetPlace(string code);
        Task<DistanceResult> GetPlacesDistance(string codeSrc, string codeDest);
    }
}
