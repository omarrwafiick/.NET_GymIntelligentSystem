using ApplicationLayer.Dtos.Members;
using MediatR; 

namespace ApplicationLayer.Queries.Reports
{ 
    public record GetRevenueReportQuery(string MemberId) : IRequest<GetRevenueReportDto>;
}
