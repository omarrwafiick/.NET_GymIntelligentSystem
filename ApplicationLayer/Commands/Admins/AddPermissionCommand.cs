 
using MediatR;

namespace ApplicationLayer.Commands.Admins
{
    public record AddPermissionCommand(
        string AdminId,
        string PermissionId
    ) : IRequest<bool>;
}
