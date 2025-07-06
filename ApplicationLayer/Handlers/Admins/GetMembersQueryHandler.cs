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
 

        async Task<List<GetMemeberDto>> IRequestHandler<GetMembersQuery, List<GetMemeberDto>>.Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _repository.GetAllAsync();
            return members.Any() ? members.Select(
                m => new GetMemeberDto(
                    m.FullName, m.Username, m.Email, m.HeightCm,
                    m.WeightKg, m.Goal, m.DateOfBirth)).ToList()
            : [];
        }
    }
} 
