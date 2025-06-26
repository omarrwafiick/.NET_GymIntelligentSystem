using MediatR; 

namespace ApplicationLayer.Commands.Admins
{
    public record RegisterAdminCommand(
        string FullName,
        string Username,
        string Email,
        string Password
    ) : IRequest<Guid?>;
}
