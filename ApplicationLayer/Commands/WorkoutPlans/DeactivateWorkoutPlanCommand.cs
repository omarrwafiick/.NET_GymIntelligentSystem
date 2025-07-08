using MediatR; 

namespace ApplicationLayer.Commands.WorkoutPlans
{ 
    public record DeactivateWorkoutPlanCommand(
         string WorkoutPlanId
    ) : IRequest<bool>;
}
