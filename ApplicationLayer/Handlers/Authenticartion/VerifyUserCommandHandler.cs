 

namespace ApplicationLayer.Handlers.Authenticartion
{
    public class VerifyUserCommandHandler : IRequestHandler<VerifyUserCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<User> _repository;

        public VerifyUserCommandHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<bool>> Handle(VerifyUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAsync(u => u.Email == request.Email);

            return user != null ?
                ServiceResult<bool>.Success("User was authenticated successfully") :
                ServiceResult<bool>.Failure("User was not authenticated"); 
        }
    }
}
