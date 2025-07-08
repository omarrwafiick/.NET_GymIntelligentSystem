 
using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Dtos.Subscriptions
{ 
    public record PurchaseSubscriptionDto(
        [Required] string MemberId, [Required] string SubscriptionId, [Required] PlanType PlanType, 
        [Required] DateTime StartDate,[Required] int DurationInDays, [Required] decimal Amount,
        [Required] CurrencyType Currency, [Required] PaymentMethod PaymentMethod, [Required] string Description);
    
    public record GetSubscriptionDto(
         Guid MemberId, PlanType PlanType,DateTime StartDate, DateTime EndDate, int DurationInDays);
     
    public record GetPaymentHistoryDto(
            Guid SubscriptionId, decimal Amount, CurrencyType Currency, 
            PaymentMethod PaymentMethod, DateTime PaidAt, string Description);

    public record UpgradeSubscriptionDto(
        [Required] DateTime StartDate, [Required] DateTime EndDate, [Required] string SubscriptionId, 
        [Required] PlanType PlanType, [Required] decimal Amount, 
        [Required] CurrencyType Currency,[Required] PaymentMethod PaymentMethod, [Required] string Description);
}
