 

namespace ApplicationLayer.Commands.Profiles
{ 
    public record UpdateProfileCommand(
        string id, string Username, string Fullname
    ) : IRequest<ServiceResult<bool>>;
}
