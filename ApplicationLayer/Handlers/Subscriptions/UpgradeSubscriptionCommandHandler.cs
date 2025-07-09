 
namespace ApplicationLayer.Handler.Subscriptions
{
    public class UpgradeSubscriptionCommandHandler : IRequestHandler<UpgradeSubscriptionCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<Subscription> _repository;

        public UpgradeSubscriptionCommandHandler(IApplicationRepository<Subscription> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<bool>> Handle(UpgradeSubscriptionCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.SubscribtionId, out Guid subscribtionId)
                || !Guid.TryParse(request.MemberId, out Guid memberId)) return ServiceResult<bool>.Failure("Invalid Id");

            var subscribtion = await _repository.GetAsync(subscribtionId);

            if (subscribtion is null || subscribtion.EndDate < DateTime.UtcNow) 
                return ServiceResult<bool>.Failure("Member was not found");

            subscribtion.Upgrade(request.StartDate, request.EndDate);

            subscribtion.AddPayment(
                PaymentHistory.Factory(memberId, subscribtionId, request.Amount, request.CurrencyType, 
                request.PaymentMethod, DateTime.UtcNow, request.Description));

            return await _repository.UpdateAsync(subscribtion) ?
                ServiceResult<bool>.Success("Subscription was upgraded successfully") :
                ServiceResult<bool>.Failure("Failed to upgrade the subscription");
        }
    }
}
