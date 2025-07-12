 

namespace ApplicationLayer.Commands.Feedbacks
{ 
    public record CreateFeedbackCommand(string UserId, int Rating, string Comment, string TargetType, string TargetId) : IRequest<ServiceResult<bool>>;

}
