 
namespace ApplicationLayer.Commands.WorkoutPlans
{ 
    public record AddWorkoutSessionCommand(
         string WorkoutPlanId, DateTime ScheduledDate, string Notes
    ) : IRequest<ServiceResult<bool>>;
}
