using ApplicationLayer.Commands.Profiles;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Profiles
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, bool>
    {
        private readonly IApplicationRepository<User> _repository;

        public DeleteAccountCommandHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
