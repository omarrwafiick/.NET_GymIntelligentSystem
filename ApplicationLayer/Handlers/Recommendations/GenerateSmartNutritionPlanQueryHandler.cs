

using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Recommendations;
using ApplicationLayer.Queries.Recommendations;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Recommendations
{
    public class GenerateSmartNutritionPlanQueryHandler : IRequestHandler<GenerateSmartNutritionPlanQuery, SmartNutritionPlanDto>
    {
        private readonly IApplicationRepository<User> _repository;

        public GenerateSmartNutritionPlanQueryHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }
 
        public Task<SmartNutritionPlanDto> Handle(GenerateSmartNutritionPlanQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
