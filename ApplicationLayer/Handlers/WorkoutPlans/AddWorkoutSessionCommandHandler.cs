
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Commands.WorkoutPlans
{
    public class AddWorkoutSessionCommandHandler : IRequestHandler<AddWorkoutSessionCommand, bool>
    {
        private readonly IApplicationRepository<WorkoutSession> _repository;

        public AddWorkoutSessionCommandHandler(IApplicationRepository<WorkoutSession> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(AddWorkoutSessionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
