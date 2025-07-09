using DomainLayer.Enums;
using MediatR; 

namespace ApplicationLayer.Commands.Feedbacks
{ 
    public record CreateFeedbackCommand(string UserId, int Rating, string Comment, TargetType TargetType, string TargetId) : IRequest<ServiceResult<bool>>;

}
