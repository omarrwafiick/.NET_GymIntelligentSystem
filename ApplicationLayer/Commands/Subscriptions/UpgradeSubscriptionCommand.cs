 
namespace ApplicationLayer.Commands.Subscriptions
{ 
    public record UpgradeSubscriptionCommand(
         string MemberId, string SubscribtionId,  DateTime StartDate, DateTime EndDate,
         PlanType PlanType,  decimal Amount, CurrencyType CurrencyType,
          PaymentMethod PaymentMethod,  string Description
    ) : IRequest<ServiceResult<bool>>;
}
