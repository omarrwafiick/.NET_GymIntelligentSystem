 

namespace ApplicationLayer.Handlers.Members
{
    public class GetNutritionPlanQueryHandler : IRequestHandler<GetNutritionPlansQuery, ServiceResult<List<GetNutritionPlanDto>>>
    {
        private readonly IApplicationRepository<NutritionPlan> _repository;
        private readonly IApplicationRepository<Member> _memberRepository;

        public GetNutritionPlanQueryHandler(
            IApplicationRepository<NutritionPlan> repository, 
            IApplicationRepository<Member> memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }

        public async Task<ServiceResult<List<GetNutritionPlanDto>>> Handle(GetNutritionPlansQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return ServiceResult<List<GetNutritionPlanDto>>.Failure("Invalid Id");

            var member = await _memberRepository.GetAsync(memberId);

            if (member is null) return ServiceResult<List<GetNutritionPlanDto>>.Failure("Member was not found");

            var nutritionPlan = member.NutritionPlans;

            return ServiceResult<List<GetNutritionPlanDto>>.Success("", nutritionPlan.Select(
                p => new GetNutritionPlanDto(p.CaloriesPerDay, p.ProteinGrams, p.CarbsGrams, p.FatsGrams, p.PlanNotes)).ToList()); 
        }
    }
}
