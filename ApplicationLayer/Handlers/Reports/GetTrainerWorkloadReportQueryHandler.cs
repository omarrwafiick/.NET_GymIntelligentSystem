 

namespace ApplicationLayer.Handlers.Reports
{
    public class GetTrainerWorkloadReportQueryHandler : IRequestHandler<GetTrainerWorkloadReportQuery, ServiceResult<GetTrainerWorkloadReportDto>>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public GetTrainerWorkloadReportQueryHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<GetTrainerWorkloadReportDto>> Handle(GetTrainerWorkloadReportQuery request, CancellationToken cancellationToken)
        { 
            if (!Guid.TryParse(request.TrainerId, out Guid trainerId)) return ServiceResult<GetTrainerWorkloadReportDto>.Failure("Invalid Id");

            var trainer = await _repository.GetAsync(trainerId);

            if (trainer is null) return ServiceResult<GetTrainerWorkloadReportDto>.Failure("Trainer was not found");

            var memebersAssigned = trainer.MemberAssignments;
            var workoutPlans = trainer.WorkoutPlans;
            var progressReportsSubmited = trainer.ProgressReportsSubmited;
            var sessions = trainer.WorkoutPlans
                .SelectMany(plan => plan.Sessions)
                .ToList();

            var now = DateTime.UtcNow;
            var startOfCurrentMonth = new DateTime(now.Year, now.Month, 1);

            var SessionsThisMonth = sessions.Where(s => s.ScheduledDate >= startOfCurrentMonth && s.ScheduledDate <= now).Count();
            var ActiveWorkoutPlans = workoutPlans.Where(w => w.StartDate < now).Count();

            var report = new GetTrainerWorkloadReportDto(
                memebersAssigned.Count(),
                ActiveWorkoutPlans,
                SessionsThisMonth,
                progressReportsSubmited.Count()
            );

            return ServiceResult<GetTrainerWorkloadReportDto>.Success("", report);
        }
    }
}
