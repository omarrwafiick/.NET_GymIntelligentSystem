 

namespace ApplicationLayer.Commands.Members
{
    public record RegisterMemberCommand(
    string FullName,
    string Username,
    string Email,
    string Password,
    float HeightCm,
    float WeightKg,
    Goal Goal,
    bool IsMale,  
    DateOnly DateOfBirth
    ) : IRequest<ServiceResult<Guid>>;
}
