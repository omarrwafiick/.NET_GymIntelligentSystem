 

namespace ApplicationLayer.Queries.WorkoutPlans
{ 
    public record GetWorkoutSessionsQuery(string MemberId) : IRequest<ServiceResult<List<GetWorkoutSessionDto>>>;

}
