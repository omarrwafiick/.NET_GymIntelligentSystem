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

        [HttpGet("members")]
        public async Task<IActionResult> GetMembeStats()
        {
            return Ok();
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenueReport()
        {
            return Ok();
        }

        [HttpGet("trainers")]
        public async Task<IActionResult> GetTrainerWorkload()
        {
            return Ok();
        }
    }
}
