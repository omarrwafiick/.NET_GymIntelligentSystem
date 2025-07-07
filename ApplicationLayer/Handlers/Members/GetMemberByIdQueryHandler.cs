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

        public async Task<GetMemeberDto> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        { 
            if (Guid.TryParse(request.MemberId, out Guid memberId)) return null;

            var member = await _repository.GetAsync(memberId);

            if (member is null) return null;

            return new GetMemeberDto(member.FullName, member.Username, member.Email, 
                member.HeightCm, member.WeightKg, member.Goal, member.DateOfBirth);
        }
    }
}
