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

        public Task<GetUserInfoDto> Handle(GetInfoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
