 

namespace ApplicationLayer.Handler.Subscriptions
{
    public class GetActiveSubscriptionsQueryHandler : IRequestHandler<GetActiveSubscriptionsQuery, ServiceResult<List<GetSubscriptionDto>>>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetActiveSubscriptionsQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<List<GetSubscriptionDto>>> Handle(GetActiveSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return ServiceResult< List < GetSubscriptionDto >>.Failure("Invalid Id");

            var member = await _repository.GetAsync(memberId);

            if (member is null) return ServiceResult<List<GetSubscriptionDto>>.Failure("Member was not found");

            var activeSubscriptions = new List<Subscription>();

            foreach (var subscription in member.Subscriptions)
            {
                if (subscription.IsActive()) activeSubscriptions.Add(subscription);
            }

            return ServiceResult<List<GetSubscriptionDto>>.Success("",
                activeSubscriptions.Select(s => {
                    var durationInDays = s.EndDate.Day - s.StartDate.Day;
                    return new GetSubscriptionDto(
                        memberId, s.PlanType, s.StartDate, s.EndDate, durationInDays
                    );
                }
                ).ToList()
            ); 
        }
    }
}
