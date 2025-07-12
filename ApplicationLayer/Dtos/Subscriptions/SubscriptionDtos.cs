  

namespace ApplicationLayer.Dtos.Subscriptions
{
    public record PurchaseSubscriptionDto(
        [Required(ErrorMessage = "Member ID is required.")]
        string MemberId,

        [Required(ErrorMessage = "Subscription ID is required.")]
        string SubscriptionId,

        [Required(ErrorMessage = "Plan type is required.")]
        string PlanType,

        [Required(ErrorMessage = "Start date is required.")]
        DateTime StartDate,

        [Required(ErrorMessage = "Duration in days is required.")]
        [Range(1, 365, ErrorMessage = "Duration must be between 1 and 365 days.")]
        int DurationInDays,

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, 100000.00, ErrorMessage = "Amount must be greater than 0.")]
        decimal Amount,

        [Required(ErrorMessage = "Currency is required.")]
        string Currency,

        [Required(ErrorMessage = "Payment method is required.")]
        string PaymentMethod,

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(3, ErrorMessage = "Description must be at least 3 characters long.")]
        string Description
    );

    public record GetSubscriptionDto(
         Guid MemberId, PlanType PlanType,DateTime StartDate, DateTime EndDate, int DurationInDays);
     
    public record GetPaymentHistoryDto(
            Guid SubscriptionId, decimal Amount, CurrencyType Currency, 
            PaymentMethod PaymentMethod, DateTime PaidAt, string Description);

    public record UpgradeSubscriptionDto(
        [Required(ErrorMessage = "Start date is required.")]
        DateTime StartDate,

        [Required(ErrorMessage = "End date is required.")]
        DateTime EndDate,

        [Required(ErrorMessage = "Subscription ID is required.")]
        string SubscriptionId,

        [Required(ErrorMessage = "Plan type is required.")]
        string PlanType,

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, 100000.00, ErrorMessage = "Amount must be greater than 0.")]
        decimal Amount,

        [Required(ErrorMessage = "Currency is required.")]
        string Currency,

        [Required(ErrorMessage = "Payment method is required.")]
        string PaymentMethod,

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(3, ErrorMessage = "Description must be at least 3 characters long.")]
        string Description
    ); 
}
