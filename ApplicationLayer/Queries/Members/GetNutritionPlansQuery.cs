 
namespace ApplicationLayer.Queries.Members
{ 
    public record GetNutritionPlansQuery(string MemberId) : IRequest<ServiceResult<List<GetNutritionPlanDto>>>;
}
