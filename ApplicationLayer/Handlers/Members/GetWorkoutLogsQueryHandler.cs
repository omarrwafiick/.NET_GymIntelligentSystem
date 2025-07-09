 

namespace ApplicationLayer.Handlers.Members
{
    public class GetWorkoutLogsQueryHandler : IRequestHandler<GetWorkoutLogsQuery, ServiceResult<List<GetWorkoutLogsDto>>>
    {
        private readonly IApplicationRepository<WorkoutLog> _repository; 
        private readonly IApplicationRepository<Member> _memberRepository;
        public GetWorkoutLogsQueryHandler(
            IApplicationRepository<WorkoutLog> repository,
            IApplicationRepository<Member> memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }
    
        public async Task<ServiceResult<List<GetWorkoutLogsDto>>> Handle(GetWorkoutLogsQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return ServiceResult<List<GetWorkoutLogsDto>>.Failure("Invalid Id");

            var member = await _memberRepository.GetAsync(memberId);

            if (member is null) return ServiceResult<List<GetWorkoutLogsDto>>.Failure("Member was not found");

            var workoutLogs = member.WorkoutLogs;

            return ServiceResult<List<GetWorkoutLogsDto>>.Success("", workoutLogs.Select(
                w => new GetWorkoutLogsDto(w.ExerciseType, w.Sets, w.Reps, w.WeightKg, w.Notes)).ToList()); 
        }
    }
}
