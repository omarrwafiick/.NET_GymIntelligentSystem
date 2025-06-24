using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/v1/workout-plans")]
    [ApiController]
    public class WorkoutPlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkoutPlansController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("{memberid}")]
        public async Task<IActionResult> CreateWorkoutPlan()
        {
            return Ok();
        }

        [HttpGet("member/{memberid}")]
        public async Task<IActionResult> GetWorkoutPlans([FromRoute] string memberid)
        {
            return Ok();
        }

        [HttpPost("{planId}/add-session")]
        public async Task<IActionResult> AddWorkoutSession([FromRoute] string planId)
        {
            return Ok();
        }

        [HttpGet("{planId}/sessions")]
        public async Task<IActionResult> GetWorkoutSession([FromRoute] string planId)
        {
            return Ok();
        }

        [HttpPost("{memberId}/history")]
        public async Task<IActionResult> GetWorkoutPlansHistory([FromRoute] string memberId)
        {
            return Ok();
        }

        [HttpPut("{planId}/reactivate")]
        public async Task<IActionResult> ReactivateWorkoutPlan([FromRoute] string planId)
        {
            return Ok();
        }
    }
}
