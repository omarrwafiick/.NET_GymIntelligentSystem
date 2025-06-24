using DomainLayer.Enums;
using MediatR; 

namespace ApplicationLayer.Commands.Members
{ 
    public record CreateWorkoutLogCommand(
        string MemberId, ExerciseType ExerciseType, int Sets, int Reps, float WeightKg, string Notes
    ) : IRequest<bool>;
}
