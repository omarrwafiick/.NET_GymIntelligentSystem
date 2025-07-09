 
namespace ApplicationLayer.Queries.Admins
{ 
    public record GetAdminByIdQuery(string AdminId) : IRequest<ServiceResult<GetAdminDto>>;
}
