
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
            Role = Role.Member;
        }
        public float HeightCm { get; private set; }
        public float WeightKg { get; private set; }
        public Goal Goal { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public virtual ICollection<WorkoutLog> WorkoutLogs { get; set; } = new List<WorkoutLog>();
        public virtual ICollection<NutritionPlan> NutritionPlans { get; set; } = new List<NutritionPlan>();
        public virtual ICollection<WorkoutPlan> WorkoutPlans { get; set; } = new List<WorkoutPlan>();
        public virtual ICollection<PaymentHistory> PaymentHistory { get; set; } = new List<PaymentHistory>();

        public static Member Factory(
            string fullName, string username, string email, string passwordHash,
            float heightCm, float weightKg, Goal goal, DateTime dateOfBirth) 
            => new Member(fullName, username, email, passwordHash,heightCm, weightKg, goal, dateOfBirth);
    }
}
