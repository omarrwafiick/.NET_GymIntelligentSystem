 using ApplicationLayer.Dtos.Subscriptions;
using MediatR; 

namespace ApplicationLayer.Queries.Admins
{ 
    public record GetSubscriptionsQuery() : IRequest<List<GetSubscriptionDto>>;
}
