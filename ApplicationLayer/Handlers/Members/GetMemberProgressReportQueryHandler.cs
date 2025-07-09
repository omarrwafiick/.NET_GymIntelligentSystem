 
namespace ApplicationLayer.Handlers.Members
{
    public class GetMemberProgressReportQueryHandler : IRequestHandler<GetMemberProgressReportQuery, ServiceResult<GetProgressReportDto>>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetMemberProgressReportQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<GetProgressReportDto>> Handle(GetMemberProgressReportQuery request, CancellationToken cancellationToken)
        { 
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return ServiceResult<GetProgressReportDto>.Failure("Invalid id");

            var member = await _repository.GetAsync(memberId);

            if (member is null) return ServiceResult<GetProgressReportDto>.Failure("Member was not found");

            var progressReport = member.ProgressReports.LastOrDefault();

            return ServiceResult<GetProgressReportDto>.Success("",
                new GetProgressReportDto(progressReport.WeightKg, progressReport.BodyFatPercentage,
                    progressReport.MuscleMass, progressReport.TrainerNotes));
        }
    }
}
