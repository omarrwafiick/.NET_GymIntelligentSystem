using MediatR; 

namespace ApplicationLayer.Commands.Authenticartion
{ 
    public record VerifyUserCommand(string Email) : IRequest<bool>;

}
