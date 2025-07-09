 
namespace ApplicationLayer.Handlers.Admins
{
    public class AddPermissionCommandHandler : IRequestHandler<AddPermissionCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<Permission> _permissionRepository;
        private readonly IApplicationRepository<AdminPermission> _adminPermissionRepository;
        private readonly IApplicationRepository<Admin> _adminRepository;
        public AddPermissionCommandHandler(
            IApplicationRepository<Permission> permissionRepository,
            IApplicationRepository<AdminPermission> adminPermissionRepository,
            IApplicationRepository<Admin> adminRepository
        )
        {
            _adminRepository = adminRepository;
            _adminPermissionRepository = adminPermissionRepository;
            _permissionRepository = permissionRepository;
        }

        public async Task<ServiceResult<bool>> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
        {  
            if (!Guid.TryParse(request.PermissionId, out Guid permissionId) ||
                !Guid.TryParse(request.AdminId, out Guid adminId)) return ServiceResult<bool>.Failure("Invalid Id");

            var permission = await _permissionRepository.GetAsync(permissionId);
            if (permission == null) return ServiceResult<bool>.Failure("Permission was not found");

            var admin = await _adminRepository.GetAsync(adminId);
            if (admin == null) return ServiceResult<bool>.Failure("Admin was not found");

            var adminPermission = await _adminPermissionRepository.GetAsync(
                ap => ap.AdminId == adminId && ap.PermissionId == permissionId);

            if (adminPermission != null) return ServiceResult<bool>.Failure("Admin already has this permission");  

            return await _adminPermissionRepository.CreateAsync(AdminPermission.Factory(adminId, permissionId)) ?
                ServiceResult<bool>.Success("Admin assigned with permission successfully") :
                ServiceResult<bool>.Failure("Failed to add this permission to admin");
            ;
        }
    }
}
