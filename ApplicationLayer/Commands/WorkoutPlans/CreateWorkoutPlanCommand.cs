 

namespace ApplicationLayer.Commands.WorkoutPlans
{ 
    public record CreateWorkoutPlanCommand(
         string MemberId, string TrainerId, PlanType PlanType, DateTime StartDate, int DurationInDays, FocusArea FocusArea
    ) : IRequest<ServiceResult<bool>>;
}
