
 

namespace ApplicationLayer.Queries.Authenticartion
{ 
    public record GetInfoQuery(string Id) : IRequest<ServiceResult<GetUserInfoDto>>;
}
