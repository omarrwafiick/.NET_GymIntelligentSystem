using ApplicationLayer.Contracts; 
using ApplicationLayer.Dtos.Trainers;
using ApplicationLayer.Queries.Reports;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Reports
{
    public class GetTrainerWorkloadReportQueryHandler : IRequestHandler<GetTrainerWorkloadReportQuery, GetTrainerWorkloadReportDto>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public GetTrainerWorkloadReportQueryHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public async Task<GetTrainerWorkloadReportDto> Handle(GetTrainerWorkloadReportQuery request, CancellationToken cancellationToken)
        { 
            if (Guid.TryParse(request.TrainerId, out Guid trainerId)) return null; 

            var trainer = await _repository.GetAsync(trainerId);

            if (trainer is null) return null;

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
            
            return new GetTrainerWorkloadReportDto(
                memebersAssigned.Count(),
                ActiveWorkoutPlans,
                SessionsThisMonth,
                progressReportsSubmited.Count()
            );
        }
    }
}
