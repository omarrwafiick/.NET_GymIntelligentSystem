 

namespace ApplicationLayer.Handlers.Reports
{
    public class GetMemberStatsReportQueryHandler : IRequestHandler<GetMemberStatsReportQuery, ServiceResult<GetMembeStatsReportDto>>
    {
        private readonly IApplicationRepository<Member> _memberRepository; 

        public GetMemberStatsReportQueryHandler(
            IApplicationRepository<Member> memberRepository)
        {
            _memberRepository = memberRepository; 
        }
    
        public async Task<ServiceResult<GetMembeStatsReportDto>> Handle(GetMemberStatsReportQuery request, CancellationToken cancellationToken)
        {  
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return ServiceResult<GetMembeStatsReportDto>.Failure("Invalid Id");

            var member = await _memberRepository.GetAsync(memberId);

            if (member is null) return ServiceResult<GetMembeStatsReportDto>.Failure("Member was not found");

            var workoutLogs = member.WorkoutLogs.ToList();
            var nutritionPlans = member.NutritionPlans.ToList();
            var lastprogressReport = member.ProgressReports.ToList()[0];
            var lastLog = workoutLogs[member.WorkoutLogs.Count() - 1];

            var now = DateTime.UtcNow;
            var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
            var workoutDaysThisMonth = workoutLogs
                .Where(w => w.PerformedOn >= firstDayOfMonth && w.PerformedOn <= now)
                .Select(w => w.PerformedOn.Date)  
                .Distinct()
                .Count();
             
            return workoutLogs.Any() && nutritionPlans.Any() ?
                ServiceResult<GetMembeStatsReportDto>.Success("",
                    new GetMembeStatsReportDto(
                    member.FullName,
                    lastLog.WeightKg,
                    workoutLogs[0].WeightKg,
                    lastprogressReport?.MuscleMass ?? 0,
                    lastprogressReport?.BodyFatPercentage ?? 0,
                    workoutLogs.Count(),
                    workoutDaysThisMonth,
                    lastLog.PerformedOn,
                    nutritionPlans.Count(),
                    member.Goal
                    )
                ) 
                :
                ServiceResult<GetMembeStatsReportDto>.Failure("Failed to get member stats");
        }
    }
}
