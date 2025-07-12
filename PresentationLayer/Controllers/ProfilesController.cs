using ApplicationLayer.Commands.Profiles;
using ApplicationLayer.Dtos.Profiles;
using MediatR;
using Microsoft.AspNetCore.Mvc; 

namespace PresentationLayer.Controllers
{
    [AuthorizeRoles(["MEMBER","TRAINER"])]
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
            var command = new UpdateProfileCommand(id, dto.Username, dto.FullName);
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                Ok(result.Message) :
                BadRequest(result.Message);
        }

        [HttpPost("{id}/change-password")]
        public async Task<IActionResult> ChangePassword([FromRoute] string id, [FromBody] ChangePasswordDto dto)
        {
            var command = new ChangePasswordCommand(id, dto.Password);
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                Ok(result.Message) :
                BadRequest(result.Message); ;
        }

        [HttpDelete("{accountid}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] string accountid)
        {
            var command = new DeleteAccountCommand(accountid);
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                Ok(result.Message) :
                BadRequest(result.Message);
        }
    }
}
