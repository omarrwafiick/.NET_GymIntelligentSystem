using MediatR; 

namespace ApplicationLayer.Commands.Profiles
{ 
    public record UpdateProfileCommand(
        string Username, string Fullname
    ) : IRequest<bool>;
}
