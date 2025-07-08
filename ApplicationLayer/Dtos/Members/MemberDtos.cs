
using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Dtos.Members
{
    public record RegisterMemberDto(
        [Required] string FullName, [Required] string Username, [Required] string Email, [Required] string Password,
        [Required] float HeightCm, [Required] float WeightKg, [Required] Goal Goal, [Required] DateOnly DateOfBirth,
        [Required] bool IsMale);
    public record CreateNutritionPlanDto(
        [Required] string MemberId, [Required] int CaloriesPerDay, [Required] float ProteinGrams,
        [Required] float CarbsGrams, [Required] float FatsGrams, [Required] string PlanNotes);
    public record CreateWorkoutLogDto(
        [Required] string MemberId, [Required] ExerciseType ExerciseType, [Required] int Sets,
        [Required] int Reps, [Required] float WeightKg, [Required] string Notes);
    public record GetMemeberDto(string FullName, string Username, string Email,
        float HeightCm, float WeightKg, Goal Goal, DateOnly DateOfBirth);

    public record GetProgressReportDto(
            float WeightKg, float BodyFatPercentage,
            float MuscleMass, string TrainerNotes);

    public record GetNutritionPlanDto(
        int CaloriesPerDay, float ProteinGrams,
        float CarbsGrams, float FatsGrams, string PlanNotes);

    public record GetWorkoutLogsDto(
        ExerciseType ExerciseType, int Sets,
        int Reps, float WeightKg, string Notes);

    public record GetMembeStatsReportDto
    (
        string FullName,
        float CurrentWeightKg,
        float StartingWeightKg,
        float BodyFatPercentage,
        float MuscleMass,
        int TotalWorkouts,
        int WorkoutDaysThisMonth,
        DateTime? LastWorkoutDate,
        int TotalNutritionPlans,
        Goal Goal
    );

    public record GetRevenueReportDto(
        decimal TotalRevenue,
         int TotalSubscriptions,
         int ActiveSubscriptions, 
         decimal LastMonthRevenue,
         int CanceledSubscriptionsThisMonth
    );
}
