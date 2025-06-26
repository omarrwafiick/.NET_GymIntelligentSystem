using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Authenticartion;
using ApplicationLayer.Queries.Authenticartion;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Authenticartion
{
    public class GetInfoQueryHandler : IRequestHandler<GetInfoQuery, GetUserInfoDto>
    {
        private readonly IApplicationRepository<User> _repository;

        public GetInfoQueryHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserInfoDto> Handle(GetInfoQuery request, CancellationToken cancellationToken)
        {
            Guid.TryParse(request.Id, out Guid id);

            var user = await _repository.GetAsync(id);  

            return user == null? null : new GetUserInfoDto(user.Email, user.Username, user.FullName);
        }
    }
}
