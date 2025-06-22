

using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class WorkoutExercise : MainEntity
    {
        private WorkoutExercise(){}
        private WorkoutExercise(
            Guid workoutSessionId, ExerciseType exerciseType, 
            int sets, int reps, float weightKg) 
        {
            WorkoutSessionId = workoutSessionId;
            ExerciseType = exerciseType;
            Sets = sets;
            Reps = reps;
            WeightKg = weightKg;
        }
        public Guid WorkoutSessionId { get; private set; }
        public WorkoutSession WorkoutSession { get; private set; } 
        public ExerciseType ExerciseType { get; private set; }  
        public int Sets { get; private set; }
        public int Reps { get; private set; }
        public float WeightKg { get; private set; }
        public static WorkoutExercise Factory
            (Guid workoutSessionId, ExerciseType exerciseType, int sets, int reps, float weightKg)
            => new WorkoutExercise(workoutSessionId, exerciseType, sets, reps, weightKg);
    }
}
