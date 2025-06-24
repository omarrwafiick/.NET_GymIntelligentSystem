using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Reports;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Reports
{
    public class GetRevenueReportQueryHandler : IRequestHandler<GetRevenueReportQuery, GetRevenueReportDto>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetRevenueReportQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public Task<GetRevenueReportDto> Handle(GetRevenueReportQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
