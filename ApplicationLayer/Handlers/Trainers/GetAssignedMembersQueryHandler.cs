 
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Trainers;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Trainers
{
    public class GetAssignedMembersQueryHandler : IRequestHandler<GetAssignedMembersQuery, List<GetMemeberDto>>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public GetAssignedMembersQueryHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public Task<List<GetMemeberDto>> Handle(GetAssignedMembersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
