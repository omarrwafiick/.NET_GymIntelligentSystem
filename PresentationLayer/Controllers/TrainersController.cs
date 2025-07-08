using ApplicationLayer.Commands.Trainers;
using ApplicationLayer.Dtos.Trainers;
using ApplicationLayer.Queries.Trainers; 
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
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
            return result.ToString() is null ?
                BadRequest("Trainer couldn't be created") :
                Ok(new { resourceId = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var query = new GetTrainerByIdQuery(id);
            var result = await _mediator.Send(query);
            return result is null ?
                NotFound($"No trainer was found using this id : {id}") :
                Ok(new { data = result });
        }

        [HttpPost("assign/{trainerid}/{memberid}")]
        public async Task<IActionResult> AssignTrainerToMember([FromRoute] string trainerid, [FromRoute] string memberid)
        {
            var command = new AssignTrainerToMemberCommand(memberid, trainerid);
            var result = await _mediator.Send(command);
            return !result ?
                BadRequest($"Couldn't assign trainer with id : {trainerid} to member with id : {memberid}") :
                NoContent();
        }

        [HttpPost("progress/{memberid}/{trainerid}")]
        public async Task<IActionResult> CreateProgressReport([FromRoute] string memberid, [FromRoute] string trainerid, [FromBody] CreateTrainerProgressReportDto dto)
        {
            var command = new CreateTrainerProgressReportCommand(
                memberid, trainerid, dto.WeightKg, dto.BodyFatPercentage, dto.MuscleMass, dto.TrainerNotes
            );
            var result = await _mediator.Send(command);
            return !result ?
                BadRequest("Progress report couldn't be created") :
                NoContent();
        }

        [HttpGet("assigned/{trainerid}")]
        public async Task<IActionResult> GetAssignedMembers([FromRoute] string trainerid)
        {
            var query = new GetAssignedMembersQuery(trainerid);
            var result = await _mediator.Send(query);
            return !result.Any() ?
                BadRequest($"Trainer with id : {trainerid} is not assigned to any user") :
                Ok(new { data = result });
        }
    }
}
