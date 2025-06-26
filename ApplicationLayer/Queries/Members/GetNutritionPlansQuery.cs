using ApplicationLayer.Dtos.Members;
using MediatR; 
namespace ApplicationLayer.Queries.Members
{ 
    public record GetNutritionPlansQuery(string MemberId) : IRequest<List<GetNutritionPlanDto>>;
}
