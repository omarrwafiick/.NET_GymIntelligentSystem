 

namespace ApplicationLayer.Queries.Members
{ 
    public record GetMemberByIdQuery(string MemberId) : IRequest<ServiceResult<GetMemeberDto>>;
}
