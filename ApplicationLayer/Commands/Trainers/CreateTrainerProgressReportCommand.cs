using MediatR; 

namespace ApplicationLayer.Commands.Trainers
{ 
    public record CreateTrainerProgressReportCommand(
         string MemberId, float WeightKg, float BodyFatPercentage,
         float MuscleMass, string TrainerNotes
    ) : IRequest<bool>;
}
