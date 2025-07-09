using ApplicationLayer.Commands.WorkoutPlans;
using ApplicationLayer.Dtos.WorkoutPlans;
using ApplicationLayer.Queries.WorkoutPlans; 
using MediatR; 
using Microsoft.AspNetCore.Mvc; 

namespace PresentationLayer.Controllers
{
    [AuthorizeRoles("MEMBER")]
    [Route("api/v1/workout-plans")]
    [ApiController]
    public class WorkoutPlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkoutPlansController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpPost("{memberid}/{trainerid}")]
        public async Task<IActionResult> CreateWorkoutPlan([FromRoute] string memberid, [FromRoute] string trainerid, [FromBody] CreateWorkoutPlanDto dto)
        {
            var command = new CreateWorkoutPlanCommand(
                memberid, trainerid, dto.PlanType, dto.StartDate, dto.DurationInDays, dto.FocusArea
            );
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        } 

        [HttpPost("{planid}/add-session")]
        public async Task<IActionResult> AddWorkoutSession([FromRoute] string planid, [FromBody] AddWorkoutSessionDto dto)
        {
            var command = new AddWorkoutSessionCommand(
               planid, dto.ScheduledDate, dto.Notes
            );
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        }

        [HttpGet("{memberid}/sessions")]
        public async Task<IActionResult> GetWorkoutSession([FromRoute] string memberid)
        {
            var query = new GetWorkoutSessionsQuery(memberid);
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
               Ok(new { data = result }) :
               BadRequest(result.Message);
        }

        [HttpGet("{memberid}/history")]
        public async Task<IActionResult> GetWorkoutPlansHistory([FromRoute] string memberid)
        {
            var query = new GetWorkoutPlansHistoryQuery(memberid);
            var result = await _mediator.Send(query); 
            return result.SuccessOrNot ?
                Ok(new { data = result }) :
                BadRequest(result.Message);
        }

        [HttpPut("{workoutplanid}/reactivate")]
        public async Task<IActionResult> ReactivateWorkoutPlan([FromRoute] string workoutplanid)
        {
            var command = new ReactivateWorkoutPlanCommand(workoutplanid);
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        }

        [HttpPut("{workoutplanid}/deactivate")]
        public async Task<IActionResult> DeactivateWorkoutPlan([FromRoute] string workoutplanid)
        {
            var command = new DeactivateWorkoutPlanCommand(workoutplanid);
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        }
    }
}
