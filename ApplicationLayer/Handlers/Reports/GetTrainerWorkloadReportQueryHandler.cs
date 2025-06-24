using ApplicationLayer.Contracts; 
using ApplicationLayer.Dtos.Trainers;
using ApplicationLayer.Queries.Reports;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Reports
{
    public class GetTrainerWorkloadReportQueryHandler : IRequestHandler<GetTrainerWorkloadReportQuery, GetTrainerWorkloadReportDto>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetTrainerWorkloadReportQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public Task<GetTrainerWorkloadReportDto> Handle(GetTrainerWorkloadReportQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
