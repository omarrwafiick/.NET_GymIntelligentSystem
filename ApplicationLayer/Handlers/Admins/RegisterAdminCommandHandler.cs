using ApplicationLayer.Commands.Admins;
using ApplicationLayer.Contracts;
using ApplicationLayer.Helpers;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Admins
{
    internal class RegisterAdminCommandHandler : IRequestHandler<RegisterAdminCommand, Guid?>
    {
        private readonly IApplicationRepository<Admin> _repository;
        private readonly IApplicationRepository<Permission> _permissionsRepository;
        private readonly IApplicationRepository<AdminPermission> _adminPermissionsRepository;
        public RegisterAdminCommandHandler(
            IApplicationRepository<Admin> repository,
            IApplicationRepository<Permission> permissionsRepository,
            IApplicationRepository<AdminPermission> adminPermissionsRepository)
        {
            _repository = repository;
            _permissionsRepository = permissionsRepository;
            _adminPermissionsRepository = adminPermissionsRepository;
        }

        public async Task<Guid?> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _repository.GetAsync(u => u.Email == request.Email);

            if (admin is not null)
                return null;

            var hashedPassword = SecurityHelpers.HashPassword(request.Password);

            admin = Admin.Factory(request.FullName, request.Username, request.Email, hashedPassword);

            var result = await _repository.CreateAsync(admin);

            if(!result) 
                return null;

            var readPermission = await _permissionsRepository.GetAsync(
                p => p.PermissionName == DomainLayer.Enums.PermissionType.Read);

            var adminPermissionResult = await _adminPermissionsRepository.CreateAsync(
                AdminPermission.Factory(admin.Id, readPermission.Id)); 

            if(!adminPermissionResult)
                return null;

            return admin.Id;
        } 
    }
}
