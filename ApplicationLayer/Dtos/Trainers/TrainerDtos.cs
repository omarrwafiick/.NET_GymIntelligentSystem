 
namespace ApplicationLayer.Dtos.Trainers
{
    public record RegisterTrainerDto(
        [Required(ErrorMessage = "Full name is required.")]
        [MinLength(3, ErrorMessage = "Full name must be at least 3 characters.")]
        string FullName,

        [Required(ErrorMessage = "Username is required.")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters.")]
        string Username,

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        string Email,

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        string Password,

        [Required(ErrorMessage = "Specialty is required.")]
        string Specialty
    );

    public record CreateTrainerProgressReportDto(
        [Required(ErrorMessage = "Member ID is required.")]
        string MemberId,

        [Required(ErrorMessage = "Trainer ID is required.")]
        string TrainerId,

        [Required(ErrorMessage = "Weight (kg) is required.")]
        [Range(20, 500, ErrorMessage = "Weight must be between 20 and 500 kg.")]
        float WeightKg,

        [Required(ErrorMessage = "Body fat percentage is required.")]
        [Range(1, 70, ErrorMessage = "Body fat percentage must be between 1 and 70%.")]
        float BodyFatPercentage,

        [Required(ErrorMessage = "Muscle mass is required.")]
        [Range(5, 100, ErrorMessage = "Muscle mass must be between 5 and 100 kg.")]
        float MuscleMass,

        [Required(ErrorMessage = "Trainer notes are required.")]
        [MinLength(5, ErrorMessage = "Notes must be at least 5 characters.")]
        string TrainerNotes
    ); 

    public record GetTrainerDto(
        string FullName,string Username, string Email, Speciality Specialty);

    public record GetTrainerWorkloadReportDto(  
        int TotalAssignedMembers,
        int ActiveWorkoutPlans,
        int SessionsThisMonth,
        int ProgressReportsSubmitted
    );

    public record GetWorkoutPlansDto(PlanType PlanType, DateTime StartDate, DateTime EndDate); 
    public record GetWorkoutSessionDto(Guid WorkoutPlanId, DateTime ScheduledDate, string Notes);
}
