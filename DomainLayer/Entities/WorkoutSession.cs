 
namespace DomainLayer.Entities
{
    public class WorkoutSession : MainEntity
    {
        private WorkoutSession(){}
        private WorkoutSession(Guid workoutPlanId, DateTime scheduledDate, string notes) 
        {
            WorkoutPlanId = workoutPlanId;
            ScheduledDate = scheduledDate;
            Notes = notes;
        }
        public Guid WorkoutPlanId { get; private set; }
        public WorkoutPlan WorkoutPlan { get; private set; } 
        public DateTime ScheduledDate { get; private set; }
        public string Notes { get; private set; } 
        public ICollection<WorkoutExercise> Exercises { get; set; } = new List<WorkoutExercise>();
        public static WorkoutSession Factory(Guid workoutPlanId, DateTime scheduledDate, string notes)
            => new WorkoutSession(workoutPlanId, scheduledDate, notes);
    }
}
