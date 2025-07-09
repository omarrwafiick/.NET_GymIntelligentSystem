  

namespace ApplicationLayer.Commands.Feedbacks
{ 
    public record ContactSupportCommand(string Message, string Subject, string UserId) : IRequest<ServiceResult<bool>>;
}
