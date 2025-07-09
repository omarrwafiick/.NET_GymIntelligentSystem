using ApplicationLayer.Commands.Feedbacks; 
using ApplicationLayer.Dtos.Feedbacks;
using ApplicationLayer.Queries.Feedbacks; 
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{

    [AuthorizeRoles("MEMBER")]
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
            return result.SuccessOrNot ?
                NoContent():
                BadRequest(result.Message);
        }

        [HttpPost("announcement")]
        public async Task<IActionResult> CreateAnnouncement([FromBody] CreateAnnouncementDto dto)
        {
            var command = new CreateAnnouncementCommand(dto.Title, dto.Message, dto.Audience);
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        }

        [HttpGet("announcements/{userid}/{audience}")]
        public async Task<IActionResult> GetAnnouncements([FromRoute] string userid, [FromRoute] string audience)
        {
            var query = new GetAnnouncementsQuery(userid, audience);
            var result = await _mediator.Send(query);
            return result.SuccessOrNot ?
                Ok(new {data = result .Data}) :
                BadRequest(result.Message);
        }

        [HttpPost("feedback")]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackDto dto)
        {
            var command = new CreateFeedbackCommand(dto.UserId, dto.Rating, dto.Comment, dto.TargetType, dto.TargetId);
            var result = await _mediator.Send(command);
            return result.SuccessOrNot ?
                NoContent() :
                BadRequest(result.Message);
        }
    }
}
