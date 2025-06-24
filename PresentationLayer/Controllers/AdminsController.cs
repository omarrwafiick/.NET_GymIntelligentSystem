using ApplicationLayer.Dtos.Admins;
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
        public async Task<IActionResult> Register([FromBody] RegisterAdminDto dto)
        { 
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return Ok();
        }


        [HttpPost("permission/{adminid}/{permissionid}")]
        public async Task<IActionResult> AddPermission([FromRoute] string adminid, [FromRoute] string permissionid)
        {
            return Ok();
        }

        [HttpGet("permissions/{adminid}")]
        public async Task<IActionResult> GetPermissions([FromRoute] string adminid)
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
