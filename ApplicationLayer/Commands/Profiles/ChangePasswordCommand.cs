using MediatR; 
namespace ApplicationLayer.Commands.Profiles
{ 
    public record ChangePasswordCommand(
        string Email, string Password
    ) : IRequest<bool>;
}
