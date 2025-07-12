 

namespace ApplicationLayer.Handlers.Admins
{
    internal class RegisterAdminCommandHandler : IRequestHandler<RegisterAdminCommand, ServiceResult<Guid>>
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

        public async Task<ServiceResult<Guid>> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _repository.GetAsync(u => u.Email == request.Email || u.Username == u.Username);

            if (admin is not null)
                return ServiceResult<Guid>.Failure("User is already exists with same email or username");

            var hashedPassword = SecurityHelpers.HashPassword(request.Password);

            admin = Admin.Factory(request.FullName, request.Username, request.Email, hashedPassword);

            var result = await _repository.CreateAsync(admin);

            if(!result)
                return ServiceResult<Guid>.Failure("Failed to create new user please try again");

            var readPermission = await _permissionsRepository.GetAsync(
                p => p.PermissionName == DomainLayer.Enums.PermissionType.Read);

            var adminPermissionResult = await _adminPermissionsRepository.CreateAsync(
                AdminPermission.Factory(admin.Id, readPermission.Id)); 

            if(!adminPermissionResult)
                return ServiceResult<Guid>.Failure("Failed to asign permission to user please contact support"); 

            return ServiceResult<Guid>.Success("Failed to create new user please try again", admin.Id);
        } 
    }
}
