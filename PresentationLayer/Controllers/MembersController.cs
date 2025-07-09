using ApplicationLayer.Commands.Members;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Members; 
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [AuthorizeRoles("MEMBER")]
    [Route("api/v1/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterMemberDto dto)
        {
            var command = new RegisterMemberCommand(
                dto.FullName, dto.Username, dto.Email, dto.Password, 
                dto.HeightCm, dto.WeightKg, dto.Goal, dto.IsMale, dto.DateOfBirth);

            var result = await _mediator.Send(command);

            return result.SuccessOrNot ?
                Ok(new { resourceId = result.Data }) :
                BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var query = new GetMemberByIdQuery(id);

            var result = await _mediator.Send(query);

            return result.SuccessOrNot ?
                Ok(new { data = result.Data }) :
                BadRequest(result.Message);
        }

        [HttpPost("{userid}/workout")]
        public async Task<IActionResult> CreateWorkoutLog([FromBody] CreateWorkoutLogDto dto)
        {
            var command = new CreateWorkoutLogCommand(
                dto.MemberId, dto.ExerciseType, dto.Sets, dto.Reps, dto.WeightKg, dto.Notes
            );

            var result = await _mediator.Send(command);

            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        }

        [HttpGet("{userid}/workout/logs")]
        public async Task<IActionResult> GetWorkoutLogs([FromRoute] string userid)
        {
            var query = new GetWorkoutLogsQuery(userid);

            var result = await _mediator.Send(query);

            return result.SuccessOrNot ?
                Ok(new { data = result.Data }) :
                BadRequest(result.Message);
        }

        [HttpPost("{memberid}/nutrition")]
        public async Task<IActionResult> CreateNutritionPlan([FromRoute] string memberid, [FromBody] CreateNutritionPlanDto dto)
        {
            var command = new CreateNutritionPlanCommand(
                memberid, dto.CaloriesPerDay, dto.ProteinGrams, dto.CarbsGrams, dto.FatsGrams, dto.PlanNotes
            );

            var result = await _mediator.Send(command);

            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        }

        [HttpGet("{memberid}/nutrition")]
        public async Task<IActionResult> GetNutritionPlans([FromRoute] string memberid)
        {
            var query = new GetNutritionPlansQuery(memberid);

            var result = await _mediator.Send(query);

            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        }

        [HttpGet("{memberid}/progress")]
        public async Task<IActionResult> GetProgressReport([FromRoute] string memberid)
        {
            var query = new GetMemberProgressReportQuery(memberid);

            var result = await _mediator.Send(query);

            return result.SuccessOrNot ?
                Ok(new { data = result.Data }) :
                BadRequest(result.Message);
        }
    }
}
