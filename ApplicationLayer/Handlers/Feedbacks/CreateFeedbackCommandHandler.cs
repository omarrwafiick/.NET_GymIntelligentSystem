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

        public Task<bool> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
