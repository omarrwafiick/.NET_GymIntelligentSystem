 
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Members;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Members
{
    public class GetNutritionPlanQueryHandler : IRequestHandler<GetNutritionPlanQuery, GetNutritionPlanDto>
    {
        private readonly IApplicationRepository<NutritionPlan> _repository;

        public GetNutritionPlanQueryHandler(IApplicationRepository<NutritionPlan> repository)
        {
            _repository = repository;
        }

        public Task<GetNutritionPlanDto> Handle(GetNutritionPlanQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
