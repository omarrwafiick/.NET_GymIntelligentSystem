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

        public async Task<List<GetSubscriptionDto>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _repository.GetAllAsync();
            return subscriptions.Any() ? subscriptions.Select(
                s => new GetSubscriptionDto(
                    s.MemberId, s.PlanType, s.StartDate, s.EndDate, 
                    (s.EndDate.Day - s.StartDate.Day), s.AmountPaid)).ToList()
            : [];
        }
    }
}
