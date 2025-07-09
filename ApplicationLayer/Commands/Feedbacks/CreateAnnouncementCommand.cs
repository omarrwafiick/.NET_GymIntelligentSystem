
 
namespace ApplicationLayer.Commands.Feedbacks
{ 
    public record CreateAnnouncementCommand(string Title, string Message, AudienceType Audience) : IRequest<ServiceResult<bool>>;
}
