
 

namespace ApplicationLayer.Queries.Admins
{ 
    public record GetMembersQuery() : IRequest<ServiceResult<List<GetMemeberDto>>>;
}
