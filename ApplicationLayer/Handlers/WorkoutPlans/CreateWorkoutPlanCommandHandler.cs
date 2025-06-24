

using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Commands.WorkoutPlans
{
    public class CreateWorkoutPlanCommandHandler : IRequestHandler<CreateWorkoutPlanCommand, bool>
    {
        private readonly IApplicationRepository<WorkoutPlan> _repository;

        public CreateWorkoutPlanCommandHandler(IApplicationRepository<WorkoutPlan> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(CreateWorkoutPlanCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
