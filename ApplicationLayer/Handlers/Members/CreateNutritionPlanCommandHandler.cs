

namespace ApplicationLayer.Handlers.Members
{
    public class CreateNutritionPlanCommandHandler : IRequestHandler<CreateNutritionPlanCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<NutritionPlan> _repository;
        private readonly IApplicationRepository<Member> _memberRepository;
        public CreateNutritionPlanCommandHandler(
            IApplicationRepository<NutritionPlan> repository, IApplicationRepository<Member> memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }

        public async Task<ServiceResult<bool>> Handle(CreateNutritionPlanCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return ServiceResult<bool>.Failure("Invalid Id");

            var member = await _memberRepository.GetAsync(memberId);

            if (member is null) return ServiceResult<bool>.Failure("Member was not found");

            return await _repository.CreateAsync(NutritionPlan.Factory(
                memberId, request.CaloriesPerDay, request.ProteinGrams,
                request.CarbsGrams, request.FatsGrams, request.PlanNotes)) ?
                ServiceResult<bool>.Success("Nutrition plan was created successfully") :
                ServiceResult<bool>.Failure("Failed to create the nutrition plan");
            ;
        }
    }
}
