 

namespace ApplicationLayer.Commands.WorkoutPlans
{ 
    public record CreateWorkoutPlanCommand(
         string MemberId, string TrainerId, string PlanType, DateTime StartDate, int DurationInDays, string FocusArea
    ) : IRequest<ServiceResult<bool>>;
}
