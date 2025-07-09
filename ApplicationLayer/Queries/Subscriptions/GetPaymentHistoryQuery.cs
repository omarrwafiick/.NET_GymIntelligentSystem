 

namespace ApplicationLayer.Queries.Subscriptions
{ 
    public record GetPaymentHistoryQuery(string MemberId) : IRequest<ServiceResult<List<GetPaymentHistoryDto>>>;
}
