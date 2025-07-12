 

namespace ApplicationLayer.Commands.Subscriptions
{ 
    public record SubscriptionPurchaseCommand(
        string MemberId, string SubscriptionId, string PlanType,
        DateTime StartDate, int DurationInDays, decimal Amount,
        string CurrencyType,  string PaymentMethod, string Description
    ) : IRequest<ServiceResult<bool>>;
}
