using ApplicationLayer.Dtos.Members; 
using MediatR;  

namespace ApplicationLayer.Queries.Reports
{ 
    public record GetMemberStatsReportQuery(string MemberId) : IRequest<GetMembeStatsReportDto>;
}
