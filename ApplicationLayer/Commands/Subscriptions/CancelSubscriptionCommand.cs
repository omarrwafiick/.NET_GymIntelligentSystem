using MediatR; 

namespace ApplicationLayer.Commands.Subscriptions
{ 
    public record CancelSubscriptionCommand(
        string subscribtionId
    ) : IRequest<bool>;
}
