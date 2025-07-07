using ApplicationLayer.Commands.Members;
using ApplicationLayer.Contracts;  
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Members
{
    public class CreateNutritionPlanCommandHandler : IRequestHandler<CreateNutritionPlanCommand, bool>
    {
        private readonly IApplicationRepository<NutritionPlan> _repository;
        private readonly IApplicationRepository<Member> _memberRepository;
        public CreateNutritionPlanCommandHandler(
            IApplicationRepository<NutritionPlan> repository, IApplicationRepository<Member> memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }

        public async Task<bool> Handle(CreateNutritionPlanCommand request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.MemberId, out Guid memberId)) return false;

            var member = await _memberRepository.GetAsync(memberId);

            if (member is null) return false;

            return await _repository.CreateAsync(NutritionPlan.Factory(
                memberId, request.CaloriesPerDay, request.ProteinGrams,
                request.CarbsGrams, request.FatsGrams, request.PlanNotes));
        }
    }
}
