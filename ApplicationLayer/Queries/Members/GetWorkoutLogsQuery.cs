 

namespace ApplicationLayer.Queries.Members
{ 
    public record GetWorkoutLogsQuery(string MemberId) : IRequest<ServiceResult<List<GetWorkoutLogsDto>>>;
}
