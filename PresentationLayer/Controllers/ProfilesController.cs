using ApplicationLayer.Commands.Profiles;
using ApplicationLayer.Dtos.Profiles;
using MediatR;
using Microsoft.AspNetCore.Mvc; 

namespace PresentationLayer.Controllers
{
    [Route("api/v1/users/profiles")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfilesController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile([FromRoute] string id, [FromBody] UpdateProfileDtos dto)
        {
            var command = new UpdateProfileCommand(id, dto.Username, dto.Fullname);
            var result = await _mediator.Send(command);
            return !result ?
                NotFound("Profile couldn't be updated") :
                NoContent(); 
        }

        [HttpPost("{id}/change-password")]
        public async Task<IActionResult> ChangePassword([FromRoute] string id, [FromBody] ChangePasswordDto dto)
        {
            var command = new ChangePasswordCommand(id, dto.Password);
            var result = await _mediator.Send(command);
            return !result ?
                NotFound("Password couldn't be changed") :
                Ok("Password was changed successfully");
        }

        [HttpDelete("{accountid}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] string accountid)
        {
            var command = new DeleteAccountCommand(accountid);
            var result = await _mediator.Send(command);
            return !result ?
                NotFound("Account couldn't be deleted") :
                NoContent();
        }
    }
}
