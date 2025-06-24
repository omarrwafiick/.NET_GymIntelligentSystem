

using ApplicationLayer.Commands.Subscriptions;
using ApplicationLayer.Contracts; 
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Subscriptions
{
    public class CancelSubscriptionCommandHandler : IRequestHandler<CancelSubscriptionCommand, bool>
    {
        private readonly IApplicationRepository<Subscription> _repository;

        public CancelSubscriptionCommandHandler(IApplicationRepository<Subscription> repository)
        {
            _repository = repository;
        } 
        public Task<bool> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
