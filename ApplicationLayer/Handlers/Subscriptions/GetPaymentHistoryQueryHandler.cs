
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Subscriptions;
using ApplicationLayer.Queries.Subscriptions;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Subscriptions
{
    public class GetPaymentHistoryQueryHandler : IRequestHandler<GetPaymentHistoryQuery, List<GetPaymentHistoryDto>>
    {
        private readonly IApplicationRepository<PaymentHistory> _repository;

        public GetPaymentHistoryQueryHandler(IApplicationRepository<PaymentHistory> repository)
        {
            _repository = repository;
        }

        public Task<List<GetPaymentHistoryDto>> Handle(GetPaymentHistoryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
