

namespace ApplicationLayer.Handlers.Authenticartion
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ServiceResult<string>>
    {
        private readonly IApplicationRepository<User> _repository; 
        private readonly ITokenProvider _tokenProvider;
        public LoginCommandHandler(IApplicationRepository<User> repository, ITokenProvider tokenProvider)
        {
            _repository = repository;
            _tokenProvider = tokenProvider;
        }

        public async Task<ServiceResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {  
            var user = await _repository.GetAsync(u => u.Email == request.Email);

            if (user is null)
                return ServiceResult<string>.Failure("User was not found");

            if (!SecurityHelpers.VerifyPassword(user.PasswordHash, request.Password))
                return ServiceResult<string>.Failure("Invalid Email or Password"); 

            return ServiceResult<string>.Success("", _tokenProvider.GenerateToken(user, user.Role.ToString()));
        }
    }
}
