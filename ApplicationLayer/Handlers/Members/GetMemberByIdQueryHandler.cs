
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Members;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Members
{
    public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, GetMemeberDto>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetMemberByIdQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public Task<GetMemeberDto> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
