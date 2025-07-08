using DomainLayer.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Commands.Subscriptions
{ 
    public record SubscriptionPurchaseCommand(
        [Required] string MemberId, [Required] string SubscriptionId, [Required] PlanType PlanType,
        [Required] DateTime StartDate, [Required] int DurationInDays, [Required] decimal Amount,
        [Required] CurrencyType CurrencyType, [Required] PaymentMethod PaymentMethod, [Required] string Description
    ) : IRequest<bool>;
}
