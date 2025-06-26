 
using ApplicationLayer.Dtos.Subscriptions; 
using MediatR; 

namespace ApplicationLayer.Queries.Subscriptions
{ 
    public record GetActiveSubscriptionsQuery(string MemberId) : IRequest<List<GetSubscriptionDto>>;

}
