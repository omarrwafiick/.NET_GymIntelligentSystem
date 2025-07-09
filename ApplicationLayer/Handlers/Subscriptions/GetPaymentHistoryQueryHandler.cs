 
namespace ApplicationLayer.Handler.Subscriptions
{
    public class GetPaymentHistoryQueryHandler : IRequestHandler<GetPaymentHistoryQuery, ServiceResult<List<GetPaymentHistoryDto>>>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetPaymentHistoryQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<List<GetPaymentHistoryDto>>> Handle(GetPaymentHistoryQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return ServiceResult<List<GetPaymentHistoryDto>>.Failure("Invalid Id");

            var member = await _repository.GetAsync(memberId);

            if (member is null) return ServiceResult<List<GetPaymentHistoryDto>>.Failure("Member was not found");

            return ServiceResult<List<GetPaymentHistoryDto>>.Success("", member.PaymentHistory.Select(p => new GetPaymentHistoryDto(
                    p.SubscriptionId, p.Amount, p.Currency, p.PaymentMethod, p.PaidAt, p.Description
                )).ToList()
            );
        }
    }
}
