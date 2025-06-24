using ApplicationLayer.Contracts; 
using ApplicationLayer.Dtos.Subscriptions;
using ApplicationLayer.Queries.Admins;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Admins
{
    public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, List<GetSubscriptionDto>>
    {
        private readonly IApplicationRepository<Subscription> _repository;

        public GetSubscriptionsQueryHandler(IApplicationRepository<Subscription> repository)
        {
            _repository = repository;
        }

        public Task<List<GetSubscriptionDto>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
