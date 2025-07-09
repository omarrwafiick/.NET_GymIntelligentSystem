 

namespace ApplicationLayer.Queries.Admins
{ 
    public record GetPermissionsQuery(string AdminId) : IRequest<ServiceResult<List<GetPermissionDto>>>;
}
