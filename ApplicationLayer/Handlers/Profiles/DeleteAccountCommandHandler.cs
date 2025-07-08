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

        public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        { 
            if (!Guid.TryParse(request.AccountId, out Guid userId)) return false;

            var user = await _repository.GetAsync(u => u.Id == userId);
            if (user == null) return false;

            return await _repository.DeleteAsync(user);
        }
    }
}
