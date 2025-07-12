 
namespace ApplicationLayer.Commands.Subscriptions
{ 
    public record UpgradeSubscriptionCommand(
         string MemberId, string SubscribtionId,  DateTime StartDate, DateTime EndDate,
         string PlanType,  decimal Amount, string CurrencyType,
         string PaymentMethod,  string Description
    ) : IRequest<ServiceResult<bool>>;
}
