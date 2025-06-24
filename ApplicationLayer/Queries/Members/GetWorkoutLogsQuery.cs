using ApplicationLayer.Dtos.Members;
using MediatR; 

namespace ApplicationLayer.Queries.Members
{ 
    public record GetWorkoutLogsQuery(string MemberId) : IRequest<List<GetWorkoutLogsDto>>;
}
