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
        public async Task<IActionResult> UpdateProfile([FromRoute] string id)
        { 
            return Ok();
        }

        [HttpPost("{id}/change-password")]
        public async Task<IActionResult> ChangePassword([FromRoute] string id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] string id)
        {
            return Ok();
        }
    }
}
