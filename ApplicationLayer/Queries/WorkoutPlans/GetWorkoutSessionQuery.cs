
using ApplicationLayer.Dtos.Trainers;
using MediatR; 

namespace ApplicationLayer.Queries.WorkoutPlans
{ 
    public record GetWorkoutSessionsQuery(string MemberId) : IRequest<List<GetWorkoutSessionDto>>;

}
