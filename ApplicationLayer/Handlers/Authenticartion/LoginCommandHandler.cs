using ApplicationLayer.Commands.Authenticartion;
using ApplicationLayer.Contracts;
using ApplicationLayer.Helpers;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Authenticartion
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IApplicationRepository<User> _repository; 
        private readonly ITokenProvider _tokenProvider;
        public LoginCommandHandler(IApplicationRepository<User> repository, ITokenProvider tokenProvider)
        {
            _repository = repository;
            _tokenProvider = tokenProvider;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {  
            var user = await _repository.GetAsync(u => u.Email == request.Email);

            if (user is null)
                return null;

            if (!SecurityHelpers.VerifyPassword(user.PasswordHash, request.Password))
                return null;

            return _tokenProvider.GenerateToken(user, user.Role.ToString());
        }
    }
}
