 
namespace ApplicationLayer.Handlers.Admins
{
    public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, ServiceResult<List<GetSubscriptionDto>>>
    {
        private readonly IApplicationRepository<Subscription> _repository;

        public GetSubscriptionsQueryHandler(IApplicationRepository<Subscription> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<List<GetSubscriptionDto>>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _repository.GetAllAsync();

            return subscriptions.Any() ?
                ServiceResult<List<GetSubscriptionDto>>.Success("",
                     subscriptions.Select(
                        s => new GetSubscriptionDto(
                            s.MemberId, s.PlanType, s.StartDate, s.EndDate,
                            (s.EndDate.Day - s.StartDate.Day))).ToList()
                ) :
                ServiceResult<List<GetSubscriptionDto>>.Failure("No subscription was found"); 
        }
    }
}
