 

namespace ApplicationLayer.Handlers.Admins
{
    public class GetAdminByIdQueryHanlder : IRequestHandler<GetAdminByIdQuery, ServiceResult<GetAdminDto>>
    {
        private readonly IApplicationRepository<Admin> _repository;

        public GetAdminByIdQueryHanlder(IApplicationRepository<Admin> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<GetAdminDto>> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        { 
            if (!Guid.TryParse(request.AdminId, out Guid adminId)) return ServiceResult<GetAdminDto>.Failure("Invalid Id");

            var admin = await _repository.GetAsync(adminId);
            return admin is not null ?
                ServiceResult<GetAdminDto>.Success("", new GetAdminDto(admin.FullName, admin.Username, admin.Email)) : 
                ServiceResult<GetAdminDto>.Failure("No admin was found");
        }
    }
}
