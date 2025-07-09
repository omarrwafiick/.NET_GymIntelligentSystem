using ApplicationLayer.Queries.Reports; 
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [AuthorizeRoles("ADMIN")]
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
            return result.SuccessOrNot ?
                Ok(new { data = result }) :
                BadRequest(result.Message);
        }

        [HttpGet("revenue/{memberid}")]
        public async Task<IActionResult> GetRevenueReport([FromRoute] string memberid)
        { 
            var query = new GetRevenueReportQuery(memberid);
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
                Ok(new { data = result }) :
                BadRequest(result.Message);
        }

        [HttpGet("trainers/{trainerid}")]
        public async Task<IActionResult> GetTrainerWorkload([FromRoute] string trainerid)
        {
            var query = new GetTrainerWorkloadReportQuery(trainerid);
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
                Ok(new { data = result }) :
                BadRequest(result.Message);
        }
    }
}
