using MediatR; 
namespace ApplicationLayer.Commands.Subscriptions
{ 
    public record UpgradeSubscriptionCommand(
        string SubscribtionId, DateTime StartDate, DateTime EndDate
    ) : IRequest<bool>;
}
