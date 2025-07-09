 
namespace ApplicationLayer.Commands.WorkoutPlans
{
    public class ReactivateWorkoutPlanCommandHandler : IRequestHandler<ReactivateWorkoutPlanCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<WorkoutPlan> _repository;

        public ReactivateWorkoutPlanCommandHandler(IApplicationRepository<WorkoutPlan> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<bool>> Handle(ReactivateWorkoutPlanCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.WorkoutPlanId, out Guid workoutPlanId)) return ServiceResult<bool>.Failure("Invalid Id/s");

            var workoutPlan = await _repository.GetAsync(workoutPlanId);

            if (workoutPlan == null) return ServiceResult<bool>.Failure("Workout plan was not found");

            workoutPlan.Reactivate();
            
            return await _repository.UpdateAsync(workoutPlan) ?
                ServiceResult<bool>.Success("Workout plan was reactivated successfully") :
                ServiceResult<bool>.Failure("Failed to reactivate the workout plan");
        }
    }
}
