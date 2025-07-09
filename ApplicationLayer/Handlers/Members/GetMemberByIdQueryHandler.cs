 

namespace ApplicationLayer.Handlers.Members
{
    public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, ServiceResult<GetMemeberDto>>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetMemberByIdQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<GetMemeberDto>> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        { 
            if (!Guid.TryParse(request.MemberId, out Guid memberId)) return ServiceResult<GetMemeberDto>.Failure("Invalid Id");

            var member = await _repository.GetAsync(memberId);

            if (member is null) return ServiceResult<GetMemeberDto>.Failure("Member was not found");

            return ServiceResult<GetMemeberDto>.Success("",
                new GetMemeberDto(member.FullName, member.Username, member.Email,
                    member.HeightCm, member.WeightKg, member.Goal, member.DateOfBirth));  
        }
    }
}
