using ApplicationLayer.Dtos.Members; 
using MediatR;  

namespace ApplicationLayer.Queries.Reports
{ 
    public record GetMembeStatsReportQuery(string MemberId) : IRequest<GetMembeStatsReportDto>;
}
