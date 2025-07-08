using MediatR; 

namespace ApplicationLayer.Commands.Subscriptions
{ 
    public record CancelSubscriptionCommand(
        string SubscribtionId
    ) : IRequest<bool>;
}
