 
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Members;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Members
{
    public class GetNutritionPlanQueryHandler : IRequestHandler<GetNutritionPlansQuery, List<GetNutritionPlanDto>>
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
          
        async Task<List<GetNutritionPlanDto>> IRequestHandler<GetNutritionPlansQuery, List<GetNutritionPlanDto>>.Handle(GetNutritionPlansQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.MemberId, out Guid memberId)) return null;

            var member = await _memberRepository.GetAsync(memberId);

            if (member is null) return null;

            var nutritionPlan = member.NutritionPlans;

            return nutritionPlan.Select(
                p => new GetNutritionPlanDto(p.CaloriesPerDay, p.ProteinGrams, p.CarbsGrams, p.FatsGrams, p.PlanNotes)).ToList();
        }
    }
}
