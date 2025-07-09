
 

namespace ApplicationLayer.Handler.Subscriptions
{
    public class CancelSubscriptionCommandHandler : IRequestHandler<CancelSubscriptionCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<Subscription> _repository;

        public CancelSubscriptionCommandHandler(IApplicationRepository<Subscription> repository)
        {
            _repository = repository;
        } 
        public async Task<ServiceResult<bool>> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.SubscribtionId, out Guid subscribtionId)) return ServiceResult<bool>.Failure("Invalid Id");

            var subscribtion = await _repository.GetAsync(subscribtionId);

            if(subscribtion is null) return ServiceResult<bool>.Failure("Subscription was not found");

            subscribtion.Cancel();

            return await _repository.UpdateAsync(subscribtion) ?
                ServiceResult<bool>.Success("Subscription was canceled successfully") :
                ServiceResult<bool>.Failure("Failed to cancel the subscription");
        }
    }
}
