using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CQRS_using_MediatR.Features.HistoricalData;
using CQRS_using_MediatR.Infrastructure.Common.Types;
using Microsoft.AspNetCore.Cors;

namespace CQRS_using_MediatR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricalDataController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HistoricalDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> GetHistoricalData()
        {
            var response = await _mediator.Send(new GetHistoricalDataRequestQuery { AggregationInterval = AggregationInterval.FifteenMinutes });
            return Ok(response);
        }
    }
}
