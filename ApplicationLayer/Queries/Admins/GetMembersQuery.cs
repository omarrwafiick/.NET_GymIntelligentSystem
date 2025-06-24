 using ApplicationLayer.Dtos.Members;
using MediatR; 

namespace ApplicationLayer.Queries.Admins
{ 
    public record GetMembersQuery() : IRequest<List<GetMemeberDto>>;
}
