

namespace ApplicationLayer.Handlers.Profiles
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<User> _repository;

        public ChangePasswordCommandHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAsync(u => u.Email == request.Email);

            if (user == null) return ServiceResult<bool>.Failure("User was not found") ; 

            var newHashedPassword = SecurityHelpers.HashPassword(request.Password);
            user.ChangePassword(newHashedPassword);

            return await _repository.UpdateAsync(user) ?
                ServiceResult<bool>.Success("User Info was updated successfully") :
                ServiceResult<bool>.Failure("User Info could't be updated");
            ;
        }
    }
}
