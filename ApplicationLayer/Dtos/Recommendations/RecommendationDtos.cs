
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
         Guid MemberId,
         PlanType PlanType,  
         int DurationInDays,
         DateTime RecommendedStartDate,
         ICollection<SmartWorkoutSessionDto> Sessions 
    );

    public record SmartWorkoutSessionDto
    (
         DateTime ScheduledDate ,
         string FocusArea ,  
         List<SmartWorkoutExerciseDto> Exercises 
    );

    public record SmartWorkoutExerciseDto
    (
          ExerciseType ExerciseType ,
          int Sets ,
          int Reps ,
          float WeightKg 
    );
}
