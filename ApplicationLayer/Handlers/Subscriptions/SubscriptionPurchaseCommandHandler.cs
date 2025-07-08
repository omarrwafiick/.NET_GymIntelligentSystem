
using ApplicationLayer.Commands.Subscriptions;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Subscriptions
{
    public class SubscriptionPurchaseCommandHandler : IRequestHandler<SubscriptionPurchaseCommand, bool>
    {
        private readonly IApplicationRepository<Subscription> _repository;
        private readonly IApplicationRepository<Member> _memberRepository;

        public SubscriptionPurchaseCommandHandler(
            IApplicationRepository<Subscription> repository, IApplicationRepository<Member> memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }

        public async Task<bool> Handle(SubscriptionPurchaseCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid memberId)
                || !Guid.TryParse(request.SubscriptionId, out Guid subscriptionId)) return false;

            var member = await _memberRepository.GetAsync(memberId);

            if (member == null) return false;

            var subscription = Subscription.Factory(memberId, request.PlanType, request.StartDate, request.DurationInDays);
           
            member.AddSubscription(subscription);

            member.AddPayment(PaymentHistory.Factory(
                memberId, subscription.Id, request.Amount, request.CurrencyType, 
                request.PaymentMethod ,request.StartDate, request.Description));

            return await _memberRepository.UpdateAsync(member);
        }
    }
}
