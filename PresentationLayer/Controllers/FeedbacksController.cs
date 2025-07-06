using ApplicationLayer.Commands.Feedbacks; 
using ApplicationLayer.Dtos.Feedbacks;
using ApplicationLayer.Queries.Feedbacks; 
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
            var command = new ContactSupportCommand(dto.Message, dto.Subject, dto.UserId);
            var result = await _mediator.Send(command);
            return !result ?
                BadRequest("Something went wrong while contacting support") :
                Ok("Message was sent successfully to support");
        }

        [HttpPost("announcement")]
        public async Task<IActionResult> CreateAnnouncement([FromBody] CreateAnnouncementDto dto)
        {
            var command = new CreateAnnouncementCommand(dto.Title, dto.Message, dto.Audience);
            var result = await _mediator.Send(command);
            return !result ?
                BadRequest("Something went wrong while creating an announcement") :
                Ok("Announcement was created successfuly");
        }

        [HttpGet("announcements/{userid}/{audience}")]
        public async Task<IActionResult> GetAnnouncements([FromRoute] string userid, [FromRoute] string audience)
        {
            var query = new GetAnnouncementsQuery(userid, audience);
            var result = await _mediator.Send(query);
            return !result.Any() ?
                NotFound("No Announcement was found") :
                Ok(new { data = result });
        }

        [HttpPost("feedback")]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackDto dto)
        {
            var command = new CreateFeedbackCommand(dto.UserId, dto.Rating, dto.Comment, dto.TargetType, dto.TargetId);
            var result = await _mediator.Send(command);
            return !result ?
                NotFound("Feedback couldn't be created") :
                Ok("Feedback was created successfully");
        }
    }
}
