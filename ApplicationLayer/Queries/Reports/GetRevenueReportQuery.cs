 

namespace ApplicationLayer.Queries.Reports
{ 
    public record GetRevenueReportQuery(string MemberId) : IRequest<ServiceResult<GetRevenueReportDto>>;
}
