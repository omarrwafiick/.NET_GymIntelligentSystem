using MediatR; 

namespace ApplicationLayer.Commands.Feedbacks
{ 
    public record ContactSupportCommand(string Message, string Subject, string UserId) : IRequest<bool>;
}
