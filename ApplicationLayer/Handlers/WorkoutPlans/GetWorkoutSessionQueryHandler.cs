 
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Trainers;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Queries.WorkoutPlans
{
    public class GetWorkoutSessionsQueryHandler : IRequestHandler<GetWorkoutSessionsQuery, List<GetWorkoutSessionDto>>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetWorkoutSessionsQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetWorkoutSessionDto>> Handle(GetWorkoutSessionsQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return [];

            var member = await _repository.GetAsync(memberId);

            if (member is null) return [];

            List<WorkoutSession> userSessions = new List<WorkoutSession>();

            foreach (var plan in member.WorkoutPlans)
            {
                userSessions.AddRange(plan.Sessions);
            }

            return userSessions.Select(w => { 
                return new GetWorkoutSessionDto(
                    w.WorkoutPlanId, w.ScheduledDate, w.Notes
                );
            })
            .ToList();
        }
    }
}
