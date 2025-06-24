using ApplicationLayer.Commands.Admins; 
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Admins
{
    public class AddPermissionCommandHandler : IRequestHandler<AddPermissionCommand, bool>
    {
        private readonly IApplicationRepository<Permission> _permissionRepository;
        private readonly IApplicationRepository<Admin> _adminRepository;
        public AddPermissionCommandHandler(
            IApplicationRepository<Permission> permissionRepository,
            IApplicationRepository<Admin> adminRepository
        )
        {
            _adminRepository = adminRepository;
            _permissionRepository = permissionRepository;
        }

        public async Task<bool> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
        {  
            return true;
        }
    }
}
