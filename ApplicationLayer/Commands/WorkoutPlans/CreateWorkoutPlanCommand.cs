using DomainLayer.Enums;
using MediatR;  

namespace ApplicationLayer.Commands.WorkoutPlans
{ 
    public record CreateWorkoutPlanCommand(
         string MemberId, PlanType PlanType, DateTime StartDate, int DurationInDays
    ) : IRequest<bool>;
}
