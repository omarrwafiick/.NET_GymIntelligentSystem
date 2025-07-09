 

namespace ApplicationLayer.Handlers.Profiles
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<User> _repository;

        public UpdateProfileCommandHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<bool>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        { 
            if (!Guid.TryParse(request.id, out Guid userId)) return ServiceResult<bool>.Failure("Invalid Id");

            var user = await _repository.GetAsync(u => u.Id == userId);
            if (user == null) return ServiceResult<bool>.Failure("User was not found");

            user.ChangeUsername(request.Username);
            user.ChangeName(request.Fullname);

            return await _repository.UpdateAsync(user) ?
                ServiceResult<bool>.Success("User profile was updated successfully"):
                ServiceResult<bool>.Failure("User profile couldn't be updated");
        }
    }
}
