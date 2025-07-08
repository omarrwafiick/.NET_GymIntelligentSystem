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

        public async Task<bool> Handle(ReactivateWorkoutPlanCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.WorkoutPlanId, out Guid workoutPlanId)) return false;

            var workoutPlan = await _repository.GetAsync(workoutPlanId);

            if (workoutPlan == null) return false;

            workoutPlan.Reactivate();
            
            return await _repository.UpdateAsync(workoutPlan);
        }
    }
}
