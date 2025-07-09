
namespace ApplicationLayer.Handlers.Admins
{
    public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, ServiceResult<List<GetMemeberDto>>>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetMembersQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<List<GetMemeberDto>>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _repository.GetAllAsync();
            return members.Any() ?
            ServiceResult<List<GetMemeberDto>>.Success("",
                members.Select(
                    m => new GetMemeberDto(
                        m.FullName, m.Username, m.Email, m.HeightCm,
                        m.WeightKg, m.Goal, m.DateOfBirth)).ToList()
                )
            :
            ServiceResult<List<GetMemeberDto>>.Failure("No member was found");
        }
    }
} 
