using MediatR; 

namespace ApplicationLayer.Commands.WorkoutPlans
{ 
    public record ReactivateWorkoutPlanCommand(
         string WorkoutPlanId
    ) : IRequest<bool>;
}
