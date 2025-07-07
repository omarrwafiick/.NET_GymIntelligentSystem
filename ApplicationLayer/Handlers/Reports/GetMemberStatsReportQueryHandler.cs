using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;  
using ApplicationLayer.Queries.Reports;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Reports
{
    public class GetMemberStatsReportQueryHandler : IRequestHandler<GetMemberStatsReportQuery, GetMembeStatsReportDto>
    {
        private readonly IApplicationRepository<Member> _memberRepository; 

        public GetMemberStatsReportQueryHandler(
            IApplicationRepository<Member> memberRepository)
        {
            _memberRepository = memberRepository; 
        }
    
        public async Task<GetMembeStatsReportDto> Handle(GetMemberStatsReportQuery request, CancellationToken cancellationToken)
        {  
            if (Guid.TryParse(request.MemberId, out Guid memberId)) return null;

            var member = await _memberRepository.GetAsync(memberId);

            if (member is null) return null;

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
                new GetMembeStatsReportDto(
                    member.FullName,
                    lastLog.WeightKg,
                    workoutLogs[0].WeightKg,
                    lastprogressReport?.MuscleMass?? 0,
                    lastprogressReport?.BodyFatPercentage ?? 0,
                    workoutLogs.Count(),
                    workoutDaysThisMonth,
                    lastLog.PerformedOn,
                    nutritionPlans.Count(),
                    member.Goal
                )
                :
                null;
        }
    }
}
