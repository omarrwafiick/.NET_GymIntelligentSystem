
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Members;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Members
{
    public class GetWorkoutLogsQueryHandler : IRequestHandler<GetWorkoutLogsQuery, List<GetWorkoutLogsDto>>
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
    
        public async Task<List<GetWorkoutLogsDto>> Handle(GetWorkoutLogsQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.MemberId, out Guid memberId)) return null;

            var member = await _memberRepository.GetAsync(memberId);

            if (member is null) return null;

            var workoutLogs = member.WorkoutLogs;

            return workoutLogs.Select(
                w => new GetWorkoutLogsDto(w.ExerciseType, w.Sets, w.Reps, w.WeightKg, w.Notes)).ToList();
        }
    }
}
