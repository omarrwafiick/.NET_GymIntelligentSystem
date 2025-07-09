 

namespace ApplicationLayer.Handler.Subscriptions
{
    public class SubscriptionPurchaseCommandHandler : IRequestHandler<SubscriptionPurchaseCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<Subscription> _repository;
        private readonly IApplicationRepository<Member> _memberRepository;

        public SubscriptionPurchaseCommandHandler(
            IApplicationRepository<Subscription> repository, IApplicationRepository<Member> memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }

        public async Task<ServiceResult<bool>> Handle(SubscriptionPurchaseCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid memberId)
                || !Guid.TryParse(request.SubscriptionId, out Guid subscriptionId)) return ServiceResult<bool>.Failure("Invalid Id");

            var member = await _memberRepository.GetAsync(memberId);

            if (member == null) return ServiceResult<bool>.Failure("Member was not found");

            var subscription = Subscription.Factory(memberId, request.PlanType, request.StartDate, request.DurationInDays);
           
            member.AddSubscription(subscription);

            member.AddPayment(PaymentHistory.Factory(
                memberId, subscription.Id, request.Amount, request.CurrencyType, 
                request.PaymentMethod ,request.StartDate, request.Description));

            return await _memberRepository.UpdateAsync(member) ?
                ServiceResult<bool>.Success("Subscription was purchased successfully") :
                ServiceResult<bool>.Failure("Failed to purchase the subscription");
        }
    }
}
