using ApplicationLayer.Commands.WorkoutPlans;
using ApplicationLayer.Dtos.WorkoutPlans;
using ApplicationLayer.Queries.WorkoutPlans; 
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
        public async Task<IActionResult> CreateWorkoutPlan([FromRoute] string memberid, [FromBody] CreateWorkoutPlanDto dto)
        {
            var command = new CreateWorkoutPlanCommand(
                memberid, dto.PlanType, dto.StartDate, dto.DurationInDays
            );
            var result = await _mediator.Send(command);
            return !result ?
                BadRequest("Workout plan couldn't be created") :
                NoContent();
        }

        [HttpGet("member/{memberid}")]
        public async Task<IActionResult> GetWorkoutPlans([FromRoute] string memberid)
        {
            var command = new GetWorkoutPlansQuery(memberid);
            var result = await _mediator.Send(command);
            return !result.Any() ?
                NotFound("Workout plan couldn't be created") :
                Ok(new {data = result});
        }

        [HttpPost("{planid}/add-session")]
        public async Task<IActionResult> AddWorkoutSession([FromRoute] string planid, [FromBody] AddWorkoutSessionDto dto)
        {
            var command = new AddWorkoutSessionCommand(
               planid, dto.ScheduledDate, dto.Notes
            );
            var result = await _mediator.Send(command);
            return !result ?
                BadRequest("Workout session couldn't be created") :
                NoContent();
        }

        [HttpGet("{memberid}/sessions")]
        public async Task<IActionResult> GetWorkoutSession([FromRoute] string memberid)
        {
            var command = new GetWorkoutSessionsQuery(memberid);
            var result = await _mediator.Send(command);
            return !result.Any() ?
                NotFound("No workout session was found") :
                Ok(new { data = result });
        }

        [HttpGet("{memberid}/history")]
        public async Task<IActionResult> GetWorkoutPlansHistory([FromRoute] string memberid)
        {
            var command = new GetWorkoutPlansHistoryQuery(memberid);
            var result = await _mediator.Send(command);
            return !result.Any() ?
                NotFound("No workout plan was found") :
                Ok(new { data = result });
        }

        [HttpPut("{workoutplanid}/reactivate")]
        public async Task<IActionResult> ReactivateWorkoutPlan([FromRoute] string workoutplanid)
        {
            var command = new ReactivateWorkoutPlanCommand(workoutplanid);
            var result = await _mediator.Send(command);
            return !result ?
                BadRequest("Workout session couldn't be reactivated") :
                NoContent();
        }
    }
}
