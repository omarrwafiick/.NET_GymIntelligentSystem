using ApplicationLayer.Dtos.Admins;
using ApplicationLayer.Dtos.Feedbacks;
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
        public async Task<IActionResult> ContactSupport([FromBody] ContactSupportDto dto)
        {
            return Ok();
        }

        [HttpPost("announcement")]
        public async Task<IActionResult> CreateAnnouncement([FromBody] CreateAnnouncementDto dto)
        {
            return Ok();
        }

        [HttpGet("announcements")]
        public async Task<IActionResult> GetAnnouncements()
        {
            return Ok();
        }

        [HttpPost("feedback")]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackDto dto)
        {
            return Ok();
        }
    }
}
