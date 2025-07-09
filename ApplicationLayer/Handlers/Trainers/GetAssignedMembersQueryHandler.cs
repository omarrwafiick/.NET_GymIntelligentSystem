  

namespace ApplicationLayer.Handler.Trainers
{
    public class GetAssignedMembersQueryHandler : IRequestHandler<GetAssignedMembersQuery, ServiceResult<List<GetMemeberDto>>>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public GetAssignedMembersQueryHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<List<GetMemeberDto>>> Handle(GetAssignedMembersQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.TrainerId, out Guid trainerId)) return ServiceResult< List < GetMemeberDto >>.Failure("Invalid Id/s");

            var trainer = await _repository.GetAsync(trainerId);

            if (trainer is null) return ServiceResult<List<GetMemeberDto>>.Failure("Trainer was not found"); ;

            return ServiceResult<List<GetMemeberDto>>.Success("", trainer.MemberAssignments.Select(
                    m => {
                        var member = m.Member;
                        return new GetMemeberDto(member.FullName, member.Username, member.Email,
                            member.HeightCm, member.WeightKg, member.Goal, member.DateOfBirth);
                    }
                ).ToList()
            ); 
             
        }
    }
}
