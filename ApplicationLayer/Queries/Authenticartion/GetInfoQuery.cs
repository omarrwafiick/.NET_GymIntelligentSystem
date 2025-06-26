using ApplicationLayer.Dtos.Authenticartion; 
using MediatR; 

namespace ApplicationLayer.Queries.Authenticartion
{ 
    public record GetInfoQuery(string Id) : IRequest<GetUserInfoDto>;
}
