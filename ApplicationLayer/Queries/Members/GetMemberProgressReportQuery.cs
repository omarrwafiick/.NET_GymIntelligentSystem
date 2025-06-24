using ApplicationLayer.Dtos.Members;
using MediatR; 

namespace ApplicationLayer.Queries.Members
{ 
    public record GetMemberProgressReportQuery(string MemberId) : IRequest<GetProgressReportDto>;
}
