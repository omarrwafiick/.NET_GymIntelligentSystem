

using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Recommendations;
using ApplicationLayer.Queries.Recommendations;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Recommendations
{
    public class GenerateSmartNutritionPlanQueryHandler : IRequestHandler<GenerateSmartNutritionPlanQuery, SmartNutritionPlanDto>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GenerateSmartNutritionPlanQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }
 
        public async Task<SmartNutritionPlanDto> Handle(GenerateSmartNutritionPlanQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.MemberId, out Guid trainerId)) return null;

            var member = await _repository.GetAsync(trainerId);

            if (member is null) return null;


            throw new NotImplementedException();
        }
    }
}
