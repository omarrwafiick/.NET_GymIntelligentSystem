using ApplicationLayer.Commands.Authenticartion;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Authenticartion
{
    public class VerifyUserCommandHandler : IRequestHandler<VerifyUserCommand, bool>
    {
        private readonly IApplicationRepository<User> _repository;

        public VerifyUserCommandHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(VerifyUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAsync(u => u.Email == request.Email);

            return user != null; 
        }
    }
}
