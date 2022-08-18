using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waniel.Domains;
using Waniel.Queries;

namespace Waniel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : BaseController
    {
        [HttpGet("{IATACode}")]
        public async Task<Airport> Get( [FromRoute] string IATACode, CancellationToken cancellationToken)
        {
            var query = new GetAirportQuery()
            {
                IATACode = IATACode,
            };
            return await Mediator.Send(query, cancellationToken);
        }
        [HttpGet("{IATACodeSrc}/dist/{IATACodeDest}")]
        public async Task<DistanceResult> GetDistance( [FromRoute] string IATACodeSrc, [FromRoute] string IATACodeDest, CancellationToken cancellationToken)
        {
            var query = new GetAirportDistanceQuery()
            {
                IATADest = IATACodeDest,
                IATASrc = IATACodeSrc,
            };
            return await Mediator.Send(query, cancellationToken);
        }
    }


}
