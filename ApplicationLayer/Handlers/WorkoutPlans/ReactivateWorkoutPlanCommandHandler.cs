
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Commands.WorkoutPlans
{
    public class ReactivateWorkoutPlanCommandHandler : IRequestHandler<ReactivateWorkoutPlanCommand, bool>
    {
        private readonly IApplicationRepository<WorkoutPlan> _repository;

        public ReactivateWorkoutPlanCommandHandler(IApplicationRepository<WorkoutPlan> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(ReactivateWorkoutPlanCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
