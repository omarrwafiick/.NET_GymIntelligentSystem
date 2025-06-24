
using ApplicationLayer.Dtos.Recommendations;
using MediatR; 

namespace ApplicationLayer.Queries.Recommendations
{ 
    public record GenerateSmartWorkoutPlanQuery(string MemberId) : IRequest<SmartWorkoutPlanDto>;

}
