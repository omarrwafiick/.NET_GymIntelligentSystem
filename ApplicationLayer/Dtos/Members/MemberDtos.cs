 

namespace ApplicationLayer.Dtos.Members
{
    public record RegisterMemberDto(
        [Required(ErrorMessage = "Full name is required.")]
        [MinLength(3, ErrorMessage = "Full name must be at least 3 characters.")]
        string FullName,

        [Required(ErrorMessage = "Username is required.")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters.")]
        string Username,

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email is not in a valid format.")]
        string Email,

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        string Password,

        [Range(30, 300, ErrorMessage = "Height must be between 30 cm and 300 cm.")]
        float HeightCm,

        [Range(20, 500, ErrorMessage = "Weight must be between 20 kg and 500 kg.")]
        float WeightKg,

        [Required(ErrorMessage = "Goal is required.")]
        string Goal,

        [Required(ErrorMessage = "Date of birth is required.")]
        DateOnly DateOfBirth,

        [Required(ErrorMessage = "Gender must be specified.")]
        bool IsMale
    );

    public record CreateNutritionPlanDto(
        [Required(ErrorMessage = "Member ID is required.")]
        string MemberId,

        [Range(1000, 10000, ErrorMessage = "Calories must be between 1000 and 10000.")]
        int CaloriesPerDay,

        [Range(0, 500, ErrorMessage = "Protein grams must be between 0 and 500.")]
        float ProteinGrams,

        [Range(0, 1000, ErrorMessage = "Carbs grams must be between 0 and 1000.")]
        float CarbsGrams,

        [Range(0, 500, ErrorMessage = "Fats grams must be between 0 and 500.")]
        float FatsGrams,

        [Required(ErrorMessage = "Plan notes are required.")]
        [MinLength(5, ErrorMessage = "Plan notes must be at least 5 characters.")]
        string PlanNotes
    );

    public record CreateWorkoutLogDto(
        [Required(ErrorMessage = "Member ID is required.")]
        string MemberId,

        [Required(ErrorMessage = "Exercise type is required.")]
        string ExerciseType,

        [Range(1, 10, ErrorMessage = "Sets must be between 1 and 10.")]
        int Sets,

        [Range(1, 50, ErrorMessage = "Reps must be between 1 and 50.")]
        int Reps,

        [Range(0, 500, ErrorMessage = "Weight must be between 0 and 500 kg.")]
        float WeightKg,

        [Required(ErrorMessage = "Workout notes are required.")]
        [MinLength(3, ErrorMessage = "Notes must be at least 3 characters.")]
        string Notes
    );

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
