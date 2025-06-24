using MediatR; 

namespace ApplicationLayer.Commands.Profiles
{ 
    public record DeleteAccountCommand(
        string AccountId
    ) : IRequest<bool>;
}
