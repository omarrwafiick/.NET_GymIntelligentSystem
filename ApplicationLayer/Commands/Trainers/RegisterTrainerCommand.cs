using DomainLayer.Enums;
using MediatR; 

namespace ApplicationLayer.Commands.Trainers
{ 
    public record RegisterTrainerCommand(
         string FullName, string Username, string Email, string Password, Speciality Specialty
    ) : IRequest<Guid>;
}
