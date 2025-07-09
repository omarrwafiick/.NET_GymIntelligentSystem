 

namespace ApplicationLayer.Commands.Subscriptions
{ 
    public record SubscriptionPurchaseCommand(
        string MemberId, string SubscriptionId,PlanType PlanType,
        DateTime StartDate, int DurationInDays, decimal Amount,
        CurrencyType CurrencyType,  PaymentMethod PaymentMethod, string Description
    ) : IRequest<ServiceResult<bool>>;
}
