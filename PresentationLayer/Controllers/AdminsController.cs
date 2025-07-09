using ApplicationLayer.Commands.Admins; 
using ApplicationLayer.Dtos.Admins;
using ApplicationLayer.Queries.Admins; 
using MediatR; 
using Microsoft.AspNetCore.Mvc; 

namespace PresentationLayer.Controllers
{
    [AuthorizeRoles("ADMIN")]
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
            return result.SuccessOrNot ?
            Ok(new { resourceId = result.Data }) :
            BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var query = new GetAdminByIdQuery(id);
            var result = await _mediator.Send(query);  
            return result.SuccessOrNot ?
                Ok(new { data = result.Data }) :
                BadRequest(result.Message); 
        } 

        [HttpPost("permission/{adminid}/{permissionid}")]
        public async Task<IActionResult> AddPermission([FromRoute] string adminid, [FromRoute] string permissionid)
        {
            var command = new AddPermissionCommand(adminid, permissionid);
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        }

        [HttpGet("permissions/{adminid}")]
        public async Task<IActionResult> GetPermissions([FromRoute] string adminid)
        {
            var query = new GetPermissionsQuery(adminid);
            var result = await _mediator.Send(query); 
            return result.SuccessOrNot ?
                Ok(new { data = result.Data }) :
                BadRequest(result.Message);
        }

        [HttpGet("members")]
        public async Task<IActionResult> GetMembers()
        {
            var query = new GetMembersQuery();
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
                Ok(new { data = result.Data }) :
                BadRequest(result.Message);
        }

        [HttpGet("trainers")]
        public async Task<IActionResult> GetTrainers()
        {
            var query = new GetTrainersQuery();
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
                Ok(new { data = result.Data }) :
                BadRequest(result.Message);
        }

        [HttpGet("subscriptions")]
        public async Task<IActionResult> GetSubscriptions()
        {
            var query = new GetSubscriptionsQuery();
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
                Ok(new { data = result.Data }) :
                BadRequest(result.Message);
        }
    }
}
