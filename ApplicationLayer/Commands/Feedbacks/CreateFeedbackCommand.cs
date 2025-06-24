using DomainLayer.Enums;
using MediatR; 

namespace ApplicationLayer.Commands.Feedbacks
{ 
    public record CreateFeedbackCommand(string userId, int rating, string comment, TargetType targetType, string targetId) : IRequest<bool>;

}
