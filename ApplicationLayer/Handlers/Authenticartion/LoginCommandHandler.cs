using ApplicationLayer.Commands.Authenticartion;
using ApplicationLayer.Contracts; 
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Authenticartion
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IApplicationRepository<User> _repository;

        public LoginCommandHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
