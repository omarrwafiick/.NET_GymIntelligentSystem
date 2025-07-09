 
namespace ApplicationLayer.Queries.WorkoutPlans
{
    public class GetWorkoutSessionsQueryHandler : IRequestHandler<GetWorkoutSessionsQuery, ServiceResult<List<GetWorkoutSessionDto>>>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetWorkoutSessionsQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<List<GetWorkoutSessionDto>>> Handle(GetWorkoutSessionsQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return ServiceResult< List < GetWorkoutSessionDto >>.Failure("Invalid Id/s");

            var member = await _repository.GetAsync(memberId);

            if (member is null) return ServiceResult<List<GetWorkoutSessionDto>>.Failure("Member was not found");

            List<WorkoutSession> userSessions = new List<WorkoutSession>();

            foreach (var plan in member.WorkoutPlans)
            {
                userSessions.AddRange(plan.Sessions);
            }

            var data = userSessions.Select(w =>
            {
                return new GetWorkoutSessionDto(
                    w.WorkoutPlanId, w.ScheduledDate, w.Notes
                );
            })
            .ToList();

            return ServiceResult<List<GetWorkoutSessionDto>>.Success("", data);
        }
    }
}
