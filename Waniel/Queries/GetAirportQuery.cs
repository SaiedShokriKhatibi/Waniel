using MediatR;
using Waniel.Domains;
using Waniel.Services;

namespace Waniel.Queries
{
    public class GetAirportQuery : IRequest<Airport>
    {
        public string IATACode { get; set; }
    }

    public class GetAirportQueryHandler : IRequestHandler<GetAirportQuery, Airport>
    {
        private readonly IPlaceService airportService;

        public GetAirportQueryHandler(IPlaceService airportService)
        {
            this.airportService = airportService;
        }
        public async Task<Airport> Handle(GetAirportQuery request, CancellationToken cancellationToken)
        {
            return (Airport)await this.airportService.GetPlace(request.IATACode);
        }
    }
}
