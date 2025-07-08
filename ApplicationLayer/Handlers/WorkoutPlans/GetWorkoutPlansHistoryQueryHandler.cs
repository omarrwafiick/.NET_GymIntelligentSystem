 
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Trainers;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Queries.WorkoutPlans
{
    public class GetWorkoutPlansHistoryQueryHandler : IRequestHandler<GetWorkoutPlansHistoryQuery, List<GetWorkoutPlansDto>>
    { 
        private readonly IApplicationRepository<Member> _memberRepository; 
        public GetWorkoutPlansHistoryQueryHandler(
            IApplicationRepository<Member> memberRepository)
        { 
            _memberRepository = memberRepository; 
        }
        public async Task<List<GetWorkoutPlansDto>> Handle(GetWorkoutPlansHistoryQuery request, CancellationToken cancellationToken)
        {  
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return [];

            var member = await _memberRepository.GetAsync(memberId); 

            if (member is null ) return [];

            return member.WorkoutPlans.Select(w => { 
                var endDate = new DateTime(w.StartDate.Year, w.StartDate.Month, w.DurationInDays);
                return new GetWorkoutPlansDto(
                    w.PlanType, w.StartDate, endDate
                );
            })
            .ToList();
        }
    }
}
