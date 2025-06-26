 
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

        public GetNutritionPlanQueryHandler(IApplicationRepository<NutritionPlan> repository)
        {
            _repository = repository;
        }
          
        Task<List<GetNutritionPlanDto>> IRequestHandler<GetNutritionPlansQuery, List<GetNutritionPlanDto>>.Handle(GetNutritionPlansQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
