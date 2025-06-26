using ApplicationLayer.Commands.Members;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Members;
using DomainLayer.Entities;
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
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
                dto.HeightCm, dto.WeightKg, dto.Goal, dto.DateOfBirth);

            var result = await _mediator.Send(command);

            return result.ToString() is null ?
                BadRequest("Something went wrong while creating new member") :
                Ok(new { resourceId = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var command = new GetMemberByIdQuery(id);

            var result = await _mediator.Send(command);

            return result is null ?
                NotFound($"No member was found using this id : {id}") :
                Ok(new { data = result });
        }

        [HttpPost("{userid}/workout")]
        public async Task<IActionResult> CreateWorkoutLog([FromBody] CreateWorkoutLogDto dto)
        {
            var command = new CreateWorkoutLogCommand(
                dto.MemberId, dto.ExerciseType, dto.Sets, dto.Reps, dto.WeightKg, dto.Notes
            );

            var result = await _mediator.Send(command);

            return !result ?
                BadRequest("Something went wrong while creating a workout log") :
                Ok("Workout log was created successfully");
        }

        [HttpGet("{userid}/workout/logs")]
        public async Task<IActionResult> GetWorkoutLogs([FromRoute] string userid)
        {
            var command = new GetWorkoutLogsQuery(userid);

            var result = await _mediator.Send(command);

            return !result.Any() ?
                NotFound("No workout log was found") :
                Ok(new { data = result });
        }

        [HttpPost("{memberid}/nutrition")]
        public async Task<IActionResult> CreateNutritionPlan([FromRoute] string memberid, [FromBody] CreateNutritionPlanDto dto)
        {
            var command = new CreateNutritionPlanCommand(
                memberid, dto.CaloriesPerDay, dto.ProteinGrams, dto.CarbsGrams, dto.FatsGrams, dto.PlanNotes
            );

            var result = await _mediator.Send(command);

            return !result ?
                BadRequest("Something went wrong while creating a nutrition plan") :
                Ok("Nutrition plan was created successfully");
        }

        [HttpGet("{memberid}/nutrition")]
        public async Task<IActionResult> GetNutritionPlans([FromRoute] string memberid)
        {
            var command = new GetNutritionPlansQuery(memberid);

            var result = await _mediator.Send(command);

            return !result.Any() ?
                NotFound($"No nutrition plan was found for member with id : {memberid}") :
                Ok("Nutrition plan was created successfully"); 
        }

        [HttpGet("{memberid}/progress")]
        public async Task<IActionResult> GetProgressReport([FromRoute] string memberid)
        {
            var command = new GetMemberProgressReportQuery(memberid);

            var result = await _mediator.Send(command);

            return result is null ?
                NotFound($"No progress report was found for member with id : {memberid}") :
                Ok(new { data = result });
        }
    }
}
