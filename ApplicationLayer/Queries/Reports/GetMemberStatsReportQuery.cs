 

namespace ApplicationLayer.Queries.Reports
{ 
    public record GetMemberStatsReportQuery(string MemberId) : IRequest<ServiceResult<GetMembeStatsReportDto>>;
}
