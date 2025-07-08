 
using DomainLayer.Enums; 

namespace DomainLayer.Entities
{
    public class WorkoutPlan : MainEntity
    {
        private WorkoutPlan() { }
        private WorkoutPlan(
            Guid memberId, Guid trainerId, PlanType planType, DateTime startDate, int durationInDays) 
        {
            MemberId = memberId;
            TrainerId = trainerId;
            PlanType = planType;
            StartDate = startDate;
            DurationInDays = durationInDays;
            IsActive = true;
        }
        public Guid MemberId { get; private set; }
        public virtual Member Member { get; private set; }
        public Guid TrainerId { get; private set; }
        public virtual Trainer Trainer { get; private set; }
        public PlanType PlanType { get; private set; }
        public DateTime StartDate { get; private set; }
        public int DurationInDays { get; private set; }
        public bool IsActive { get; private set; }
        public void Deactivate()
        {
            IsActive = false;
        } 
        public void Reactivate()
        {
            IsActive = true;
        }
        public virtual ICollection<WorkoutSession> Sessions { get; private set; } = new List<WorkoutSession>();
        public static WorkoutPlan Factory
            (Guid memberId, Guid trainerId, PlanType planType, DateTime startDate
            , int durationInDays)
            => new WorkoutPlan(memberId, trainerId, planType, startDate, durationInDays);
    }
}
