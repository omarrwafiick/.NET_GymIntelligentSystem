 

namespace ApplicationLayer.Commands.Authenticartion
{
    public record LoginCommand(string Email, string Password) : IRequest<ServiceResult<string>>;
}
