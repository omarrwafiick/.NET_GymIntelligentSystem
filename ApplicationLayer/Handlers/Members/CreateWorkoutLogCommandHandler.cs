 
namespace ApplicationLayer.Handlers.Members
{
    public class CreateWorkoutLogCommandHandler : IRequestHandler<CreateWorkoutLogCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<WorkoutLog> _repository;
        private readonly IApplicationRepository<Member> _memberRepository;
        public CreateWorkoutLogCommandHandler(
            IApplicationRepository<WorkoutLog> repository, IApplicationRepository<Member> memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }
        public async Task<ServiceResult<bool>> Handle(CreateWorkoutLogCommand request, CancellationToken cancellationToken)
        {
            var exercises = Enum.GetValues(typeof(ExerciseType)).Cast<string>().ToArray();

            if (!exercises.Any(a => a == request.ExerciseType)) ServiceResult<bool>.Failure("Invalid exercise");

            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return ServiceResult<bool>.Failure("Invalid Id");

            var member = await _memberRepository.GetAsync(memberId);

            if (member is null) return ServiceResult<bool>.Failure("Member was not found");

            return await _repository.CreateAsync(WorkoutLog.Factory(
                memberId, Enum.Parse<ExerciseType>(request.ExerciseType), request.Sets,
                request.Reps, request.WeightKg, request.Notes)) ? 
                ServiceResult<bool>.Success("Workout log was created successfully") :
                ServiceResult<bool>.Failure("Failed to create the workout log");

        }
    }
}
