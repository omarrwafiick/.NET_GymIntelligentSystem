using DomainLayer.Enums; 

namespace DomainLayer.Entities
{
    public class Subscription : MainEntity
    {
        private Subscription() { }

        private Subscription(Guid memberId, PlanType planType, DateTime startDate, int durationInDays)
        {
            MemberId = memberId;
            PlanType = planType;
            StartDate = startDate;
            EndDate = startDate.AddDays(durationInDays);  
            Status = SubscriptionStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid MemberId { get; private set; }
        public virtual Member Member { get; private set; }
        public PlanType PlanType { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; } 
        public SubscriptionStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public virtual List<PaymentHistory> PaymentHistories { get; set; } = new List<PaymentHistory>();

        public void AddPayment(PaymentHistory paymentHistory)
        {
            PaymentHistories.Add(paymentHistory);
        }
        public static Subscription Factory(Guid memberId, PlanType planType, DateTime startDate, int durationInDays)
            => new Subscription(memberId, planType, startDate, durationInDays);

        public void Cancel()
            => Status = SubscriptionStatus.Cancelled;

        public void Pend()
            => Status = SubscriptionStatus.PendingPayment;

        public void Expire()
            => Status = SubscriptionStatus.Expired;

        public void Upgrade(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
        public bool IsActive() => Status == SubscriptionStatus.Active && EndDate > DateTime.UtcNow;
    }

}
