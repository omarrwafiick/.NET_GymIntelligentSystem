using ApplicationLayer.Dtos.Admins;
using MediatR;  

namespace ApplicationLayer.Queries.Admins
{ 
    public record GetAdminByIdQuery(string AdminId) : IRequest<GetAdminDto>;
}
