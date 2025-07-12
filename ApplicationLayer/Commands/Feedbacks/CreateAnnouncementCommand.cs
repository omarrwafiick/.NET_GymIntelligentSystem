
 
namespace ApplicationLayer.Commands.Feedbacks
{ 
    public record CreateAnnouncementCommand(string Title, string Message, string Audience) : IRequest<ServiceResult<bool>>;
}
