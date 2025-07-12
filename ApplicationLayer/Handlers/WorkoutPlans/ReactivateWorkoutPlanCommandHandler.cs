 

namespace ApplicationLayer.Commands.WorkoutPlans
{
    public class DeactivateWorkoutPlanCommandHandler : IRequestHandler<DeactivateWorkoutPlanCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<WorkoutPlan> _repository;

        public DeactivateWorkoutPlanCommandHandler(IApplicationRepository<WorkoutPlan> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<bool>> Handle(DeactivateWorkoutPlanCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.WorkoutPlanId, out Guid workoutPlanId)) return ServiceResult<bool>.Failure("Invalid Id/s");

            var workoutPlan = await _repository.GetAsync(workoutPlanId);

            if (workoutPlan == null) return ServiceResult<bool>.Failure("Workout plan was not found");

            if (!workoutPlan.IsActive) return ServiceResult<bool>.Failure("Workout plan is already deactivated");

            workoutPlan.Deactivate();
            
            return await _repository.UpdateAsync(workoutPlan) ?
                ServiceResult<bool>.Success("Workout plan was deactivated successfully") :
                ServiceResult<bool>.Failure("Failed to deactivate the workout plan");
        }
    }
}
