using ApplicationLayer.Dtos.Subscriptions;
using MediatR; 

namespace ApplicationLayer.Queries.Subscriptions
{ 
    public record GetPaymentHistoryQuery() : IRequest<List<GetPaymentHistoryDto>>;
}
