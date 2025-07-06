using ApplicationLayer.Queries.Reports; 
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    //TODOS : verify role = admin
    [Route("api/v1/admin/reports/stats")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpGet("member/{memberid}")]
        public async Task<IActionResult> GetMemberStats([FromRoute] string memberid)
        {
            var query = new GetMemberStatsReportQuery(memberid);
            var result = await _mediator.Send(query);
            return result is null ?
                NotFound($"No stats was found for memeber with id : {memberid}") :
                Ok(new { data = result });
        }

        [HttpGet("revenue/{memberid}")]
        public async Task<IActionResult> GetRevenueReport([FromRoute] string memberid)
        { 
            var query = new GetRevenueReportQuery(memberid);
            var result = await _mediator.Send(query);
            return result is null ?
                NotFound($"No revenue report was found for memeber with id : {memberid}") :
                Ok(new { data = result });
        }

        [HttpGet("trainers/{trainerid}")]
        public async Task<IActionResult> GetTrainerWorkload([FromRoute] string trainerid)
        {
            var query = new GetTrainerWorkloadReportQuery(trainerid);
            var result = await _mediator.Send(query);
            return result is null ?
                NotFound($"No work load was found for trainer with id : {trainerid}") :
                Ok(new { data = result });
        }
    }
}
