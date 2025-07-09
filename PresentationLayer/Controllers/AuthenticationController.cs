using ApplicationLayer.Commands.Authenticartion;
using ApplicationLayer.Dtos.Authenticartion;
using ApplicationLayer.Queries.Authenticartion;
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var command = new LoginCommand(dto.Email, dto.Password);
            var result = await _mediator.Send(command);
            HttpContext.Response.Cookies.Append("token", result.Data);
            return result.SuccessOrNot ?
                Ok(new { token = result.Data }) :
                BadRequest(result.Message);
        }
         
        [HttpGet("info/{id}")]
        public async Task<IActionResult> GetInfo([FromRoute] string id)
        {
            var command = new GetInfoQuery(id);
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                Ok(new { data = result.Data }) :
                BadRequest(result.Message);
        }

        [HttpPost("verify")]
        public async Task<IActionResult> Verify([FromBody] string email)
        {
            var command = new VerifyUserCommand(email);
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                Ok(new { data = result.Data }) :
                BadRequest(result.Message);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("token");
            return Ok();
        }
    }
}
