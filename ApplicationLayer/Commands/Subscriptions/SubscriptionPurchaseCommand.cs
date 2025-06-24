using DomainLayer.Enums;
using MediatR; 

namespace ApplicationLayer.Commands.Subscriptions
{ 
    public record SubscriptionPurchaseCommand(
        string MemberId, PlanType PlanType, DateTime StartDate, int DurationInDays, decimal Amount
    ) : IRequest<bool>;
}
