
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Member : User
    {
        private Member() { }
        private Member(
            string fullName, string username, string email, string passwordHash,
            float heightCm, float weightKg, Goal goal, DateOnly dateOfBirth, Gender gender) 
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
            Gender = gender;
        }
        public float HeightCm { get; private set; }
        public float WeightKg { get; private set; }
        public Gender Gender { get; private set; }
        public Goal Goal { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public virtual IEnumerable<WorkoutLog> WorkoutLogs { get; private set; } = new List<WorkoutLog>();
        public virtual IEnumerable<NutritionPlan> NutritionPlans { get; private set; } = new List<NutritionPlan>();
        public virtual IEnumerable<WorkoutPlan> WorkoutPlans { get; private set; } = new List<WorkoutPlan>();
        public virtual List<PaymentHistory> PaymentHistory { get; private set; } = new List<PaymentHistory>();
        public virtual IEnumerable<ProgressReport> ProgressReports { get; private set; } = new List<ProgressReport>();
        public virtual List<Subscription> Subscriptions { get; private set; } = new List<Subscription>();

        public void AddSubscription(Subscription subscription)
        {
            Subscriptions.Add(subscription);
        } 
        public void AddPayment(PaymentHistory paymentHistory)
        {
            PaymentHistory.Add(paymentHistory);
        }
        public static Member Factory(
            string fullName, string username, string email, string passwordHash,
            float heightCm, float weightKg, Goal goal, DateOnly dateOfBirth, Gender gender) 
            => new Member(fullName, username, email, passwordHash,heightCm, weightKg, goal, dateOfBirth, gender);
    }
}
