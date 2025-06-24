

using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Dtos.WorkoutPlans
{
    public record AddWorkoutSessionDto(
        [Required] string WorkoutPlanId, [Required] DateTime ScheduledDate, [Required] string Notes);
    public record CreateWorkoutPlanDto(
            [Required] string MemberId, [Required] PlanType PlanType,
            [Required] DateTime StartDate, [Required] int DurationInDays); 

}
