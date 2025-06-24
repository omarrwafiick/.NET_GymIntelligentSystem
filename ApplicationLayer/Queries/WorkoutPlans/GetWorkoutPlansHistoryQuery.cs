
using ApplicationLayer.Dtos.Trainers;
using MediatR; 

namespace ApplicationLayer.Queries.WorkoutPlans
{ 
    public record GetWorkoutPlansHistoryQuery(string MemberId) : IRequest<List<GetWorkoutPlansDto>>;
}
