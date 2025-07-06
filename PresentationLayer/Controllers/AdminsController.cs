using ApplicationLayer.Commands.Admins; 
using ApplicationLayer.Dtos.Admins;
using ApplicationLayer.Queries.Admins; 
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
            var command = new RegisterAdminCommand(dto.FullName, dto.Username, dto.Email, dto.Password);
            var result = await _mediator.Send(command);
            return result.ToString() is null ?
                NotFound("Account couldn't be created") :
                Ok(new { resourceId = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var query = new GetAdminByIdQuery(id);
            var result = await _mediator.Send(query);
            return result is null ?
                NotFound($"No admin was found using this id {id}") :
                Ok(new { data = result });
        } 

        [HttpPost("permission/{adminid}/{permissionid}")]
        public async Task<IActionResult> AddPermission([FromRoute] string adminid, [FromRoute] string permissionid)
        {
            var command = new AddPermissionCommand(adminid, permissionid);
            var result = await _mediator.Send(command);
            return !result ?
                NotFound("Permission couldn't be added") :
                NoContent();
        }

        [HttpGet("permissions/{adminid}")]
        public async Task<IActionResult> GetPermissions([FromRoute] string adminid)
        {
            var query = new GetPermissionsQuery(adminid);
            var result = await _mediator.Send(query);
            return !result.Any() ?
                NotFound("No permission was found") :
                Ok(new {data = result });
        }

        [HttpGet("members")]
        public async Task<IActionResult> GetMembers()
        {
            var query = new GetMembersQuery();
            var result = await _mediator.Send(query);
            return !result.Any() ?
                NotFound("No member was found") :
                Ok(new { data = result });
        }

        [HttpGet("trainers")]
        public async Task<IActionResult> GetTrainers()
        {
            var query = new GetTrainersQuery();
            var result = await _mediator.Send(query);
            return !result.Any() ?
                NotFound("No trainer was found") :
                Ok(new { data = result });
        }

        [HttpGet("subscriptions")]
        public async Task<IActionResult> GetSubscriptions()
        {
            var query = new GetSubscriptionsQuery();
            var result = await _mediator.Send(query);
            return !result.Any() ?
                NotFound("No subscription was found") :
                Ok(new { data = result });
        }
    }
}
