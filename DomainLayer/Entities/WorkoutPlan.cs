 
using DomainLayer.Enums; 

namespace DomainLayer.Entities
{
    public class WorkoutPlan : MainEntity
    {
        private WorkoutPlan() { }
        private WorkoutPlan(
            Guid memberId, PlanType planType, DateTime startDate
            , int durationInDays, ICollection<WorkoutSession> sessions) 
        {
            MemberId = memberId;
            PlanType = planType;
            StartDate = startDate;
            DurationInDays = durationInDays;
            Sessions = sessions;
        }
        public Guid MemberId { get; private set; }
        public Member Member { get; private set; } 
        public PlanType PlanType { get; private set; }
        public DateTime StartDate { get; private set; }
        public int DurationInDays { get; private set; }
        public ICollection<WorkoutSession> Sessions { get; private set; } = new List<WorkoutSession>();
        public static WorkoutPlan Factory
            (Guid memberId, PlanType planType, DateTime startDate
            , int durationInDays, ICollection<WorkoutSession> sessions)
            => new WorkoutPlan(memberId, planType, startDate, durationInDays, sessions);
    }
}
