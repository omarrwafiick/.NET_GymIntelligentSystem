 
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

        public async Task<List<GetMemeberDto>> Handle(GetAssignedMembersQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.TrainerId, out Guid trainerId)) return [];
             
            var trainer = await _repository.GetAsync(trainerId);

            if (trainer is null) return [];

            return trainer.MemberAssignments.Select(
                m => {
                    var member = m.Member;
                    return new GetMemeberDto(member.FullName, member.Username, member.Email,
                        member.HeightCm, member.WeightKg, member.Goal, member.DateOfBirth);
                }
            ).ToList(); 
        }
    }
}
