 
namespace ApplicationLayer.Commands.WorkoutPlans
{
    public class AddWorkoutSessionCommandHandler : IRequestHandler<AddWorkoutSessionCommand, ServiceResult<bool>>
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

        public async Task<ServiceResult<bool>> Handle(AddWorkoutSessionCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.WorkoutPlanId, out Guid workoutPlanId)) return ServiceResult<bool>.Failure("Invalid Id/s");

            var workplan = await _workoutPlanRepository.GetAsync(workoutPlanId);
            
            var endDate = new DateTime(workplan.StartDate.Year, workplan.StartDate.Month, workplan.DurationInDays);
            //invalid session
            if (workplan is null || endDate < DateTime.UtcNow) 
                return ServiceResult<bool>.Failure("Session was expired please upgrade it to add logs");

            return await _repository.CreateAsync(WorkoutSession.Factory(
                workoutPlanId, request.ScheduledDate, request.Notes
            )) ?
                ServiceResult<bool>.Success("Session was created successfully") :
                ServiceResult<bool>.Failure("Failed to create the session"); ;
        }
    }
}
