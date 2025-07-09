 
namespace ApplicationLayer.Queries.Subscriptions
{ 
    public record GetActiveSubscriptionsQuery(string MemberId) : IRequest<ServiceResult<List<GetSubscriptionDto>>>;

}
