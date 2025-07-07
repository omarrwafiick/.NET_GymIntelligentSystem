using ApplicationLayer.Commands.Feedbacks;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Feedbacks
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, bool>
    {
        private readonly IApplicationRepository<Feedback> _repository;

        public CreateFeedbackCommandHandler(IApplicationRepository<Feedback> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        { 

            if (Guid.TryParse(request.UserId, out Guid userId) 
                || Guid.TryParse(request.TargetId, out Guid targetId)) return false;

            var feedback = Feedback.Factory(userId, request.Rating, request.Comment, request.TargetType, targetId);

            return await _repository.CreateAsync(feedback);
        }
    }
}
