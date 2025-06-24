using ApplicationLayer.Dtos.Admins; 
using MediatR; 

namespace ApplicationLayer.Queries.Admins
{ 
    public record GetPermissionsQuery(string AdminId) : IRequest<List<GetPermissionDto>>;
}
