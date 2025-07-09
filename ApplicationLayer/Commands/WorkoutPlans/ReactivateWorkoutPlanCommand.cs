 
namespace ApplicationLayer.Commands.WorkoutPlans
{ 
    public record ReactivateWorkoutPlanCommand(
         string WorkoutPlanId
    ) : IRequest<ServiceResult<bool>>;
}
