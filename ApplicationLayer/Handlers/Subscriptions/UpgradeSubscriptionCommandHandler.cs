

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
            if (Guid.TryParse(request.SubscribtionId, out Guid subscribtionId)) return false;

            var subscribtion = await _repository.GetAsync(subscribtionId);

            if (subscribtion is null) return false;

            subscribtion.Upgrade(request.StartDate, request.EndDate);

            return await _repository.UpdateAsync(subscribtion);
        }
    }
}
