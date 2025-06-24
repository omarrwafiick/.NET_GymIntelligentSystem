

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

        public Task<bool> Handle(UpgradeSubscriptionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
