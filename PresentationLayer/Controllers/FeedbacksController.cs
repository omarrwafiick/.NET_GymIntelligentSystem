using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/v1/feedbacks")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FeedbacksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("support/contact")]
        public async Task<IActionResult> ContactSupport()
        {
            return Ok();
        }

        [HttpPost("announcements")]
        public async Task<IActionResult> CreateAnnouncements()
        {
            return Ok();
        }

        [HttpGet("fetch/announcements")]
        public async Task<IActionResult> GetAnnouncements()
        {
            return Ok();
        }

        [HttpPost("feedback")]
        public async Task<IActionResult> CreateFeedback()
        {
            return Ok();
        }
    }
}
