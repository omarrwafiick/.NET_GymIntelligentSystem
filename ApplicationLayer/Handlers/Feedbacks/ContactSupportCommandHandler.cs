 
namespace ApplicationLayer.Handlers.Feedbacks
{
    public class ContactSupportCommandHandler : IRequestHandler<ContactSupportCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<SupportMessage> _repository;

        public ContactSupportCommandHandler(IApplicationRepository<SupportMessage> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<bool>> Handle(ContactSupportCommand request, CancellationToken cancellationToken)
        { 
            if (!Guid.TryParse(request.UserId, out Guid userId)) return ServiceResult<bool>.Failure("Invalid Id");

            var contactMessage = SupportMessage.Factory(request.Message, request.Subject, userId);

            return await _repository.CreateAsync(contactMessage) ?
                ServiceResult<bool>.Success("Message was sent successfully") :
                ServiceResult<bool>.Failure("Failed to send message");
        }
    }
}
