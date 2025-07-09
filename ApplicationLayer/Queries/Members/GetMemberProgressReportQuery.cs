 

namespace ApplicationLayer.Queries.Members
{ 
    public record GetMemberProgressReportQuery(string MemberId) : IRequest<ServiceResult<GetProgressReportDto>>;
}
