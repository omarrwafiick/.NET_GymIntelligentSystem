 

namespace ApplicationLayer.Queries.Admins
{ 
    public record GetSubscriptionsQuery() : IRequest<ServiceResult<List<GetSubscriptionDto>>>;
}
