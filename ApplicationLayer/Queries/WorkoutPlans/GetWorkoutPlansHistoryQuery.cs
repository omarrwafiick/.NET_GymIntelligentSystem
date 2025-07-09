 

namespace ApplicationLayer.Queries.WorkoutPlans
{ 
    public record GetWorkoutPlansHistoryQuery(string MemberId) : IRequest<ServiceResult<List<GetWorkoutPlansDto>>>;
}
