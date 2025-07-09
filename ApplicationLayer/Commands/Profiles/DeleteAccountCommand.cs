 
namespace ApplicationLayer.Commands.Profiles
{ 
    public record DeleteAccountCommand(
        string AccountId
    ) : IRequest<ServiceResult<bool>>;
}
