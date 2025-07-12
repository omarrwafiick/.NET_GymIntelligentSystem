 
namespace ApplicationLayer.Commands.Trainers
{ 
    public record RegisterTrainerCommand(
         string FullName, string Username, string Email, string Password, string Specialty
    ) : IRequest<ServiceResult<Guid>>;
}
