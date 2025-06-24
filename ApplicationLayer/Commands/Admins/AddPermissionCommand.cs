 
using MediatR;

namespace ApplicationLayer.Commands.Admins
{
    public record AddPermissionCommand(
        int AdminId,
        int PermissionId
    ) : IRequest<bool>;
}
