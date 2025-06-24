using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Admins;
using DomainLayer.Entities;
using MediatR; 

namespace ApplicationLayer.Handlers.Admins
{
    public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, List<GetMemeberDto>>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetMembersQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }
 

        Task<List<GetMemeberDto>> IRequestHandler<GetMembersQuery, List<GetMemeberDto>>.Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
} 
