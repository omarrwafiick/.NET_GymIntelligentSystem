 
namespace ApplicationLayer.Commands.Trainers
{ 
    public record CreateTrainerProgressReportCommand(
         string MemberId, string TrainerId, float WeightKg, float BodyFatPercentage,
         float MuscleMass, string TrainerNotes
    ) : IRequest<ServiceResult<bool>>;
}
