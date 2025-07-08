

using ApplicationLayer.Commands.Subscriptions;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Subscriptions
{
    public class UpgradeSubscriptionCommandHandler : IRequestHandler<UpgradeSubscriptionCommand, bool>
    {
        private readonly IApplicationRepository<Subscription> _repository;

        public UpgradeSubscriptionCommandHandler(IApplicationRepository<Subscription> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpgradeSubscriptionCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.SubscribtionId, out Guid subscribtionId)
                || !Guid.TryParse(request.MemberId, out Guid memberId)) return false;

            var subscribtion = await _repository.GetAsync(subscribtionId);

            if (subscribtion is null || subscribtion.EndDate < DateTime.UtcNow) return false;

            subscribtion.Upgrade(request.StartDate, request.EndDate);

            subscribtion.AddPayment(
                PaymentHistory.Factory(memberId, subscribtionId, request.Amount, request.CurrencyType, 
                request.PaymentMethod, DateTime.UtcNow, request.Description));

            return await _repository.UpdateAsync(subscribtion);
        }
    }
}
