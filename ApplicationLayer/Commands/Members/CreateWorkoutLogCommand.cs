 

namespace ApplicationLayer.Commands.Members
{ 
    public record CreateWorkoutLogCommand(
        string MemberId, string ExerciseType, int Sets, int Reps, float WeightKg, string Notes
    ) : IRequest<ServiceResult<bool>>;
}
