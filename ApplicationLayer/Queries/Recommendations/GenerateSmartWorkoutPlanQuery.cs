 

namespace ApplicationLayer.Queries.Recommendations
{ 
    public record GenerateSmartWorkoutPlanQuery(string MemberId) : IRequest<ServiceResult<SmartWorkoutPlanDto>>;

}
