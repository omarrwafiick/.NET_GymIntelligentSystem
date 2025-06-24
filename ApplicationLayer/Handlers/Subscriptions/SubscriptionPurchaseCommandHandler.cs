
using ApplicationLayer.Commands.Subscriptions;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Subscriptions
{
    public class SubscriptionPurchaseCommandHandler : IRequestHandler<SubscriptionPurchaseCommand, bool>
    {
        private readonly IApplicationRepository<Subscription> _repository;

        public SubscriptionPurchaseCommandHandler(IApplicationRepository<Subscription> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(SubscriptionPurchaseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
