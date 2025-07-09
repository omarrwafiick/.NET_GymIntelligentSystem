 

namespace ApplicationLayer.Handlers.Authenticartion
{
    public class GetInfoQueryHandler : IRequestHandler<GetInfoQuery, ServiceResult<GetUserInfoDto>>
    {
        private readonly IApplicationRepository<User> _repository;

        public GetInfoQueryHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<GetUserInfoDto>> Handle(GetInfoQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.Id, out Guid id)) return ServiceResult<GetUserInfoDto>.Failure("Invalid Id");

            var user = await _repository.GetAsync(id);  

            return user == null? 
                ServiceResult<GetUserInfoDto>.Failure("User was not found") :
                ServiceResult<GetUserInfoDto>.Success("", new GetUserInfoDto(user.Email, user.Username, user.FullName)); 
        }
    }
}
