using MediatR; 
namespace ApplicationLayer.Commands.Subscriptions
{ 
    public record UpgradeSubscriptionCommand(
        string subscribtionId
    ) : IRequest<bool>;
}
