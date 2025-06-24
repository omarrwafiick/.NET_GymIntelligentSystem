
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Subscriptions;
using ApplicationLayer.Queries.Subscriptions;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Subscriptions
{
    public class GetActiveSubscriptionsQueryHandler : IRequestHandler<GetActiveSubscriptionsQuery, List<GetSubscriptionDto>>
    {
        private readonly IApplicationRepository<Subscription> _repository;

        public GetActiveSubscriptionsQueryHandler(IApplicationRepository<Subscription> repository)
        {
            _repository = repository;
        }

        public Task<List<GetSubscriptionDto>> Handle(GetActiveSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
