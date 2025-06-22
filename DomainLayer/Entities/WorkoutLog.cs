
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class WorkoutLog : MainEntity
    {
        private WorkoutLog(){ }
        private WorkoutLog(Guid memberId, ExerciseType exerciseType, int sets, int reps,
            float weightKg, string notes) 
        {
            MemberId = memberId;
            ExerciseType = exerciseType;
            Sets = sets;
            Reps = reps;
            WeightKg = weightKg;
            Notes = notes;
            PerformedOn = DateTime.UtcNow;
        } 
        public Guid MemberId { get; private set; }
        public virtual Member Member { get; private set; } 
        public DateTime PerformedOn { get; private set; }
        public ExerciseType ExerciseType { get; private set; }
        public int Sets { get; private set; }
        public int Reps { get; private set; }
        public float WeightKg { get; private set; }
        public string Notes { get; private set; } 
        public static WorkoutLog Factory
            (Guid memberId, ExerciseType exerciseType, int sets, int reps,float weightKg, string notes)
            => new WorkoutLog(memberId, exerciseType, sets, reps, weightKg, notes);
    }
}
