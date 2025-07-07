using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Members;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Members
{
    public class GetMemberProgressReportQueryHandler : IRequestHandler<GetMemberProgressReportQuery, GetProgressReportDto>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetMemberProgressReportQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<GetProgressReportDto> Handle(GetMemberProgressReportQuery request, CancellationToken cancellationToken)
        { 
            if (Guid.TryParse(request.MemberId, out Guid memberId)) return null;

            var member = await _repository.GetAsync(memberId);

            if (member is null) return null;

            var progressReport = member.ProgressReports.LastOrDefault();

            return new GetProgressReportDto(progressReport.WeightKg, progressReport.BodyFatPercentage, 
                progressReport.MuscleMass, progressReport.TrainerNotes);
        }
    }
}
