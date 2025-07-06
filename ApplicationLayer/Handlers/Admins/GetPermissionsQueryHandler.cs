using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Admins; 
using ApplicationLayer.Queries.Admins;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Admins
{
    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, List<GetPermissionDto>>
    {
        private readonly IApplicationRepository<Permission> _repository;

        public GetPermissionsQueryHandler(IApplicationRepository<Permission> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissions = await _repository.GetAllAsync();
            return permissions.Any() ? permissions.Select(
                p => new GetPermissionDto(p.Id, p.PermissionName.ToString())).ToList()
            : [];
        }
    }
}
