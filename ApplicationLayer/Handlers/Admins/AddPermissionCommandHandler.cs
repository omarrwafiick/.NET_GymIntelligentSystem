using ApplicationLayer.Commands.Admins; 
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Admins
{
    public class AddPermissionCommandHandler : IRequestHandler<AddPermissionCommand, bool>
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

        public async Task<bool> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
        {  
            if (!Guid.TryParse(request.PermissionId, out Guid permissionId) ||
                !Guid.TryParse(request.AdminId, out Guid adminId)) return false;

            var permission = await _permissionRepository.GetAsync(permissionId);
            if (permission == null) return false;

            var admin = await _adminRepository.GetAsync(adminId);
            if (admin == null) return false;

            var adminPermission = await _adminPermissionRepository.GetAsync(
                ap => ap.AdminId == adminId && ap.PermissionId == permissionId);

            if (adminPermission != null) return false;  

            return await _adminPermissionRepository.CreateAsync(AdminPermission.Factory(adminId, permissionId));
        }
    }
}
