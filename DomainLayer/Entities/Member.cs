
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Member : User
    {
        private Member() { }
        private Member(
            string fullName, string username, string email, string passwordHash,
            float heightCm, float weightKg, Goal goal, DateTime dateOfBirth) 
        {
            FullName = fullName;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            HeightCm = heightCm;
            WeightKg = weightKg;
            Goal = goal;
            DateOfBirth = dateOfBirth;
        }
        public float HeightCm { get; private set; }
        public float WeightKg { get; private set; }
        public Goal Goal { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public ICollection<WorkoutLog> WorkoutLogs { get; private set; } = new List<WorkoutLog>();
        public ICollection<NutritionPlan> NutritionPlans { get; private set; } = new List<NutritionPlan>();
        public ICollection<WorkoutPlan> WorkoutPlans { get; private set; } = new List<WorkoutPlan>();
        public void AddWorkoutLogs(WorkoutLog workoutLog) => WorkoutLogs.Add(workoutLog);
        public void AddNutritionPlans(NutritionPlan nutritionPlan) => NutritionPlans.Add(nutritionPlan);
        public void AddWorkoutPlans(WorkoutPlan workoutPlans) => WorkoutPlans.Add(workoutPlans);
        public static Member Factory(
            string fullName, string username, string email, string passwordHash,
            float heightCm, float weightKg, Goal goal, DateTime dateOfBirth) 
            => new Member(fullName, username, email, passwordHash,heightCm, weightKg, goal, dateOfBirth);
    }
}
