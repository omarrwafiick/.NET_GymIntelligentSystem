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
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        [HttpPost("assign/{trainerid}/{memberid}")]
        public async Task<IActionResult> AssignTrainerToMember([FromRoute] string trainerid, [FromRoute] string memberid)
        {
            return Ok();
        }

        [HttpPost("progress/{trainerid}")]
        public async Task<IActionResult> CreateProgressReport([FromRoute] string trainerid)
        {
            return Ok();
        }

        [HttpGet("assigned/{trainerid}")]
        public async Task<IActionResult> GetAssignedMembers([FromRoute] string trainerid)
        {
            return Ok();
        }
    }
}
