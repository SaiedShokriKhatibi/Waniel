using MediatR;
using Waniel.Domains;
using Waniel.Services;

namespace Waniel.Queries
{
    public class GetAirportDistanceQuery : IRequest<DistanceResult>
    {
        public string IATASrc { get; set; }
        public string IATADest { get; set; }
    }

    public class GetAirportDistanceQueryHandler : IRequestHandler<GetAirportDistanceQuery, DistanceResult>
    {
        private readonly IPlaceService airportService;

        public GetAirportDistanceQueryHandler( IPlaceService airportService)
        {
            this.airportService = airportService;
        }
        public Task<DistanceResult> Handle(GetAirportDistanceQuery request, CancellationToken cancellationToken)
        {
            return airportService.GetPlacesDistance(request.IATASrc, request.IATADest);
        }
    }
}
