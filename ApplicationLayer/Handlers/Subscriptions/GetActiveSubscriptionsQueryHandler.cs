
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Subscriptions;
using ApplicationLayer.Queries.Subscriptions;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Subscriptions
{
    public class GetActiveSubscriptionsQueryHandler : IRequestHandler<GetActiveSubscriptionsQuery, List<GetSubscriptionDto>>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetActiveSubscriptionsQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSubscriptionDto>> Handle(GetActiveSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.MemberId, out Guid memberId)) return [];

            var member = await _repository.GetAsync(memberId);

            if (member is null) return []; 
            
            var activeSubscriptions = new List<Subscription>();

            foreach (var subscription in member.Subscriptions)
            {
                if (subscription.IsActive()) activeSubscriptions.Add(subscription);
            }

            return activeSubscriptions.Select(s => { 
                var durationInDays = s.EndDate.Day - s.StartDate.Day;
                return new GetSubscriptionDto(
                    memberId, s.PlanType, s.StartDate, s.EndDate, durationInDays
                );
            }
            ).ToList();
        }
    }
}
