using Newtonsoft.Json;
using System.Text.Json;
using Waniel.Domains;

namespace Waniel.Services
{
    public class AirportService : IPlaceService
    {
        private readonly IMapService mapService;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public AirportService( 
            IMapService mapService,
            IHttpClientFactory httpClientFactory, 
            IConfiguration configuration)
        {
            this.mapService = mapService;
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }

        public async Task<IPlace> GetPlace(string IATACode)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{configuration["AirportUrl"]}{IATACode}");
            var httpClient = httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                using var reader = new StreamReader(contentStream);
                var content = reader.ReadToEnd();
                //Airport? airport = await JsonSerializer.DeserializeAsync<Airport>(content);
                Airport airport = JsonConvert.DeserializeObject<Airport>(content);
                return airport;
            }
            else
            {
                return null;
            }
        }

        public async Task<DistanceResult> GetPlacesDistance(string IATACodeSrc, string IATACodeDest)
        {
            var airportSrc = await GetPlace(IATACodeSrc);
            var airportDest = await GetPlace(IATACodeDest);
            if (airportDest != null && airportSrc != null)
            {
                //use GoogleService
                //var result = await this.googleService.GetDistance(from: airportSrc.Location, to: airportDest.Location);

                //use Local calculation
                //var result = await ((LocalService)mapService).GetDistance(from: airportSrc.Location, to: airportDest.Location);

                //use .Net core GeoCoordinatePortable
                var result = await ((DotNetService)mapService).GetDistance(from: airportSrc.Location, to: airportDest.Location);

                return new DistanceResult { Distance = result };
            }
            else
            {
                throw new Exception("Invalide IATA Codes");
            }
        }

    }
}
