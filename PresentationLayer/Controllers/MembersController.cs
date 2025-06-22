using ApplicationLayer.Dtos;
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
        public async Task<IActionResult> Register([FromBody] MembersDtos data)
        {
            //var command = new RegisterMemberCommand();
            //var id = await _mediator.Send(command);
            var id = 1;
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        { 
            return Ok();
        }
    }
}
