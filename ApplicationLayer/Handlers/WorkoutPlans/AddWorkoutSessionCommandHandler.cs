
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Commands.WorkoutPlans
{
    public class AddWorkoutSessionCommandHandler : IRequestHandler<AddWorkoutSessionCommand, bool>
    {
        private readonly IApplicationRepository<WorkoutSession> _repository;
        private readonly IApplicationRepository<WorkoutPlan> _workoutPlanRepository;

        public AddWorkoutSessionCommandHandler(
            IApplicationRepository<WorkoutSession> repository,
            IApplicationRepository<WorkoutPlan> workoutPlanRepository)
        {
            _repository = repository;
            _workoutPlanRepository = workoutPlanRepository;
        }

        public async Task<bool> Handle(AddWorkoutSessionCommand request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.WorkoutPlanId, out Guid workoutPlanId)) return false;

            var workplan = await _workoutPlanRepository.GetAsync(workoutPlanId);
            
            var endDate = new DateTime(workplan.StartDate.Year, workplan.StartDate.Month, workplan.DurationInDays);
            //invalid session
            if (workplan is null || endDate < DateTime.UtcNow) return false;

            return await _repository.CreateAsync(WorkoutSession.Factory(
                workoutPlanId, request.ScheduledDate, request.Notes
            ));
        }
    }
}
