using ApplicationLayer.Dtos.Trainers;
using MediatR; 

namespace ApplicationLayer.Queries.WorkoutPlans
{ 
    public record GetWorkoutPlansQuery(string MemberId) : IRequest<List<GetWorkoutPlansDto>>;
}
