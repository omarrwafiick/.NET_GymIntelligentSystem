 
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

        public Task<bool> Handle(ContactSupportCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
