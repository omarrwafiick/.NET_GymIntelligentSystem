using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Commands.WorkoutPlans
{
    public class DeactivateWorkoutPlanCommandHandler : IRequestHandler<DeactivateWorkoutPlanCommand, bool>
    {
        private readonly IApplicationRepository<WorkoutPlan> _repository;

        public DeactivateWorkoutPlanCommandHandler(IApplicationRepository<WorkoutPlan> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeactivateWorkoutPlanCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.WorkoutPlanId, out Guid workoutPlanId)) return false;

            var workoutPlan = await _repository.GetAsync(workoutPlanId);

            if (workoutPlan == null) return false;

            workoutPlan.Deactivate();
            
            return await _repository.UpdateAsync(workoutPlan);
        }
    }
}
