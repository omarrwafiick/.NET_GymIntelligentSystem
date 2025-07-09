 
 
namespace ApplicationLayer.Queries.Recommendations
{ 
    public record GenerateSmartNutritionPlanQuery(string MemberId) : IRequest<ServiceResult<SmartNutritionPlanDto>>;
}
