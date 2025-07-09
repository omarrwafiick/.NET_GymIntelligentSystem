 
namespace ApplicationLayer.Handlers.Admins
{
    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, ServiceResult<List<GetPermissionDto>>>
    {
        private readonly IApplicationRepository<Permission> _repository;

        public GetPermissionsQueryHandler(IApplicationRepository<Permission> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<List<GetPermissionDto>>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissions = await _repository.GetAllAsync();
            return permissions.Any() ?
            ServiceResult<List<GetPermissionDto>>.Success("", 
                permissions.Select(
                    p => new GetPermissionDto(p.Id, p.PermissionName.ToString()))
                    .ToList()
            ):
            ServiceResult<List<GetPermissionDto>>.Failure("No persmission was found");
        }
    }
}
