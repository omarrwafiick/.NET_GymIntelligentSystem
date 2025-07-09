using ApplicationLayer.Commands.Trainers;
using ApplicationLayer.Dtos.Trainers;
using ApplicationLayer.Queries.Trainers; 
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [AuthorizeRoles("TRAINER")]
    [Route("api/v1/trainers")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainersController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterTrainerDto dto)
        {
            var command = new RegisterTrainerCommand(
                dto.FullName, dto.Username, dto.Email, dto.Password, dto.Specialty
            );
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                Ok(new { resourceId = result.Data }) :
                BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var query = new GetTrainerByIdQuery(id);
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
                Ok(new { data = result.Data }) :
                BadRequest(result.Message);
        }

        [HttpPost("assign/{trainerid}/{memberid}")]
        public async Task<IActionResult> AssignTrainerToMember([FromRoute] string trainerid, [FromRoute] string memberid)
        {
            var command = new AssignTrainerToMemberCommand(memberid, trainerid);
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
              NoContent() :
              BadRequest(result.Message);
        }

        [HttpPost("progress/{memberid}/{trainerid}")]
        public async Task<IActionResult> CreateProgressReport([FromRoute] string memberid, [FromRoute] string trainerid, [FromBody] CreateTrainerProgressReportDto dto)
        {
            var command = new CreateTrainerProgressReportCommand(
                memberid, trainerid, dto.WeightKg, dto.BodyFatPercentage, dto.MuscleMass, dto.TrainerNotes
            );
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
             NoContent() :
             BadRequest(result.Message);
        }

        [HttpGet("assigned/{trainerid}")]
        public async Task<IActionResult> GetAssignedMembers([FromRoute] string trainerid)
        {
            var query = new GetAssignedMembersQuery(trainerid);
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
                Ok(new { data = result.Data }) :
                BadRequest(result.Message);
        }
    }
}
