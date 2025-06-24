 
using ApplicationLayer.Dtos.Members;
using MediatR; 


namespace ApplicationLayer.Queries.Members
{ 
    public record GetMemberByIdQuery(string MemberId) : IRequest<GetMemeberDto>;
}
