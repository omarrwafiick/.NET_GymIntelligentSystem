 
using ApplicationLayer.Commands.Feedbacks;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Feedbacks
{
    public class ContactSupportCommandHandler : IRequestHandler<ContactSupportCommand, bool>
    {
        private readonly IApplicationRepository<SupportMessage> _repository;

        public ContactSupportCommandHandler(IApplicationRepository<SupportMessage> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ContactSupportCommand request, CancellationToken cancellationToken)
        {
            Guid.TryParse(request.UserId, out Guid userId);
            if (userId.ToString() is null) return false;

            var contactMessage = SupportMessage.Factory(request.Message, request.Subject, userId);

            return await _repository.CreateAsync(contactMessage);
        }
    }
}
