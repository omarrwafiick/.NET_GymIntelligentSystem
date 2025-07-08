
using DomainLayer.Enums;

namespace ApplicationLayer.Dtos.Recommendations
{
    public record SmartNutritionPlanDto(
         int CaloriesPerDay,
         float ProteinGrams,
         float CarbsGrams,
         float FatsGrams,
         string PlanNotes,
         int DurationInDays, 
         DateTime RecommendedStartDate
    );

    public record SmartWorkoutPlanDto( 
         PlanType PlanType,  
         int DurationInDays,
         DateTime RecommendedStartDate,
         SmartWorkoutSessionDto Session
    );

    public record SmartWorkoutSessionDto
    (
         DateTime ScheduledDate,
         string FocusArea,  
         SmartWorkoutExerciseDto Exercise
    );

    public record SmartWorkoutExerciseDto
    (
          ExerciseType ExerciseType,
          int Sets,
          int Reps
    );
}
