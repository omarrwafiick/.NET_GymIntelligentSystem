 

namespace ApplicationLayer.Dtos.WorkoutPlans
{
    public record AddWorkoutSessionDto(
        [Required(ErrorMessage = "Workout Plan ID is required.")]
        string WorkoutPlanId,

        [Required(ErrorMessage = "Scheduled date is required.")]
        DateTime ScheduledDate,

        [Required(ErrorMessage = "Notes are required.")]
        [MinLength(5, ErrorMessage = "Notes must be at least 5 characters long.")]
        string Notes
    );

    public record CreateWorkoutPlanDto(
        [Required(ErrorMessage = "Member ID is required.")]
        string MemberId,

        [Required(ErrorMessage = "Plan type is required.")]
        PlanType PlanType,

        [Required(ErrorMessage = "Start date is required.")]
        DateTime StartDate,

        [Required(ErrorMessage = "Duration in days is required.")]
        [Range(1, 365, ErrorMessage = "Duration must be between 1 and 365 days.")]
        int DurationInDays,

        [Required(ErrorMessage = "Focus area is required.")]
        FocusArea FocusArea
    );  
}
