
using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Dtos.Trainers
{
    public record RegisterTrainerDto(
        [Required] string FullName, [Required] string Username, [Required] string Email, 
        [Required] string Password, [Required] Speciality Specialty);
    public record CreateTrainerProgressReportDto(
        [Required] string MemberId, [Required] float WeightKg, [Required] float BodyFatPercentage,
        [Required] float MuscleMass, [Required] string TrainerNotes);

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
