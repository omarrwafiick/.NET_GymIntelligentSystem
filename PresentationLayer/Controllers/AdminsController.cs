using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/v1/admins")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminsController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateAdmin()
        { 
            return Ok();
        }

        [HttpPost("permission/{id}")]
        public async Task<IActionResult> AddPermission([FromRoute] string id)
        {
            return Ok();
        }

        [HttpGet("members")]
        public async Task<IActionResult> GetMembers()
        {
            return Ok();
        }

        [HttpGet("trainers")]
        public async Task<IActionResult> GetTrainers()
        {
            return Ok();
        }

        [HttpGet("subscriptions")]
        public async Task<IActionResult> GetSubscriptions()
        {
            return Ok();
        }
    }
}
