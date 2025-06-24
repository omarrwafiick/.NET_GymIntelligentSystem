

using ApplicationLayer.Commands.Profiles;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Profiles
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IApplicationRepository<User> _repository;

        public ChangePasswordCommandHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
