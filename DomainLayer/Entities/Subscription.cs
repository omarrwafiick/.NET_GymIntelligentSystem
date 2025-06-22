using DomainLayer.Enums; 

namespace DomainLayer.Entities
{
    public class Subscription : MainEntity
    {
        private Subscription() { }

        private Subscription(Guid memberId, PlanType planType, DateTime startDate, int durationInDays, decimal amount)
        {
            MemberId = memberId;
            PlanType = planType;
            StartDate = startDate;
            EndDate = startDate.AddDays(durationInDays);
            AmountPaid = amount;
            Status = SubscriptionStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid MemberId { get; private set; }
        public virtual Member Member { get; private set; }
        public PlanType PlanType { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public decimal AmountPaid { get; private set; }
        public SubscriptionStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public static Subscription Factory(Guid memberId, PlanType planType, DateTime startDate, int durationInDays, decimal amount)
            => new Subscription(memberId, planType, startDate, durationInDays, amount);

        public void Cancel()
            => Status = SubscriptionStatus.Cancelled;

        public void Pend()
            => Status = SubscriptionStatus.PendingPayment;

        public void Expire()
            => Status = SubscriptionStatus.Expired;
        public bool IsActive() => Status == SubscriptionStatus.Active && EndDate > DateTime.UtcNow;
    }

}
