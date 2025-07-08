
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Subscriptions;
using ApplicationLayer.Queries.Subscriptions;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Subscriptions
{
    public class GetPaymentHistoryQueryHandler : IRequestHandler<GetPaymentHistoryQuery, List<GetPaymentHistoryDto>>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetPaymentHistoryQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPaymentHistoryDto>> Handle(GetPaymentHistoryQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.MemberId, out Guid memberId)) return [];

            var member = await _repository.GetAsync(memberId);

            if (member is null) return [];

            return member.PaymentHistory.Select(p => new GetPaymentHistoryDto(
                    p.SubscriptionId, p.Amount, p.Currency, p.PaymentMethod, p.PaidAt, p.Description
            )).ToList();
        }
    }
}
