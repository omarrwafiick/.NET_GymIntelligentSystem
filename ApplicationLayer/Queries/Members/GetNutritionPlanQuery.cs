using ApplicationLayer.Dtos.Members;
using MediatR; 
namespace ApplicationLayer.Queries.Members
{ 
    public record GetNutritionPlanQuery(string MemberId) : IRequest<GetNutritionPlanDto>;
}
