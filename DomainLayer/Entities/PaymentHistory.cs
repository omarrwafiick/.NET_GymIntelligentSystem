
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class PaymentHistory : MainEntity
    {
        private PaymentHistory() { }

        private PaymentHistory(Guid memberId, decimal amount, CurrencyType currency, PaymentMethod paymentMethod, string transactionId, DateTime paidAt, string description)
        {
            MemberId = memberId;
            Amount = amount;
            Currency = currency;
            PaymentMethod = paymentMethod;
            TransactionId = transactionId;
            PaidAt = paidAt;
            Description = description;
        }

        public Guid MemberId { get; private set; }
        public virtual Member Member { get; private set; } 
        public decimal Amount { get; private set; }
        public CurrencyType Currency { get; private set; }  
        public PaymentMethod PaymentMethod { get; private set; } 
        public string TransactionId { get; private set; }  
        public DateTime PaidAt { get; private set; } 
        public string Description { get; private set; } 

        public static PaymentHistory Factory(
            Guid memberId,
            decimal amount,
            CurrencyType currency,
            PaymentMethod paymentMethod,
            string transactionId,
            DateTime paidAt,
            string description
        )
        {
            return new PaymentHistory(memberId, amount, currency, paymentMethod, transactionId, paidAt, description);
        }
    }

}
