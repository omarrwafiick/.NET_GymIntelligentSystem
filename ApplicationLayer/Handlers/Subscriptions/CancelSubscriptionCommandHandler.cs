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
        public async Task<bool> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.SubscribtionId, out Guid subscribtionId)) return false;

            var subscribtion = await _repository.GetAsync(subscribtionId);

            if(subscribtion is null) return false;

            subscribtion.Cancel();

            return await _repository.UpdateAsync(subscribtion);
        }
    }
}
