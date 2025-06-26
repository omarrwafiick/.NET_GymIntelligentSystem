using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;  
using ApplicationLayer.Queries.Reports;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Reports
{
    public class GetMemberStatsReportQueryHandler : IRequestHandler<GetMemberStatsReportQuery, GetMembeStatsReportDto>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetMemberStatsReportQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }
    
        public Task<GetMembeStatsReportDto> Handle(GetMemberStatsReportQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
