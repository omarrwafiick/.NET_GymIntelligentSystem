 
namespace ApplicationLayer.Handlers.Feedbacks
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<Feedback> _repository;

        public CreateFeedbackCommandHandler(IApplicationRepository<Feedback> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<bool>> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        { 

            if (!Guid.TryParse(request.UserId, out Guid userId) 
                || !Guid.TryParse(request.TargetId, out Guid targetId)) return ServiceResult<bool>.Failure("Invalid Id");

            var feedback = Feedback.Factory(userId, request.Rating, request.Comment, request.TargetType, targetId);

            return await _repository.CreateAsync(feedback) ?
                ServiceResult<bool>.Success("Feedback was created successfully") :
                ServiceResult<bool>.Failure("Failed to create the feedback");
        }
    }
}
