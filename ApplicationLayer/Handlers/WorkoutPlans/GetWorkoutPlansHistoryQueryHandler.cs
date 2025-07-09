 

namespace ApplicationLayer.Queries.WorkoutPlans
{
    public class GetWorkoutPlansHistoryQueryHandler : IRequestHandler<GetWorkoutPlansHistoryQuery, ServiceResult<List<GetWorkoutPlansDto>>>
    { 
        private readonly IApplicationRepository<Member> _memberRepository; 
        public GetWorkoutPlansHistoryQueryHandler(
            IApplicationRepository<Member> memberRepository)
        { 
            _memberRepository = memberRepository; 
        }
        public async Task<ServiceResult<List<GetWorkoutPlansDto>>> Handle(GetWorkoutPlansHistoryQuery request, CancellationToken cancellationToken)
        {  
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return ServiceResult< List < GetWorkoutPlansDto >>.Failure("Invalid Id/s");

            var member = await _memberRepository.GetAsync(memberId); 

            if (member is null ) return ServiceResult<List<GetWorkoutPlansDto>>.Failure("Member was not found");

            var data = member.WorkoutPlans.Select(w => {
                var endDate = new DateTime(w.StartDate.Year, w.StartDate.Month, w.DurationInDays);
                return new GetWorkoutPlansDto(
                    w.PlanType, w.StartDate, endDate
                );
            })
            .ToList();

            return ServiceResult<List<GetWorkoutPlansDto>>.Success("", data);
        }
    }
}
