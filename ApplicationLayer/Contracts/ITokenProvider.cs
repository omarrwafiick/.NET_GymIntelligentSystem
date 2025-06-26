

using DomainLayer.Entities;

namespace ApplicationLayer.Contracts
{
    public interface ITokenProvider
    {
        string GenerateToken(User user, string role);
    }
}
