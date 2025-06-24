 
using ApplicationLayer.Dtos.Recommendations;
using MediatR; 

namespace ApplicationLayer.Queries.Recommendations
{ 
    public record GenerateSmartNutritionPlanQuery(string MemberId) : IRequest<SmartNutritionPlanDto>;
}
