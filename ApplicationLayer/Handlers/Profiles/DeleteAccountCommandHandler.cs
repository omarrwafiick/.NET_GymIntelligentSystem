 

namespace ApplicationLayer.Handlers.Profiles
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<User> _repository;

        public DeleteAccountCommandHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<bool>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        { 
            if (!Guid.TryParse(request.AccountId, out Guid userId)) return ServiceResult<bool>.Failure("Invalid Id");

            var user = await _repository.GetAsync(u => u.Id == userId);
            if (user == null) return ServiceResult<bool>.Failure("User was not found");

            return await _repository.DeleteAsync(user) ?
                 ServiceResult<bool>.Success("User was deleted successfully") :
                 ServiceResult<bool>.Failure("User couldn't be deleted");
        }
    }
}
