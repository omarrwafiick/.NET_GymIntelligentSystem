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

        public Task<List<GetPermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
