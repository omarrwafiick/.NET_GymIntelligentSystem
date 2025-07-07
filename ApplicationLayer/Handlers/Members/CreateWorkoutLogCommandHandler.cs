using ApplicationLayer.Commands.Members;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Members
{
    public class CreateWorkoutLogCommandHandler : IRequestHandler<CreateWorkoutLogCommand, bool>
    {
        private readonly IApplicationRepository<WorkoutLog> _repository;
        private readonly IApplicationRepository<Member> _memberRepository;
        public CreateWorkoutLogCommandHandler(
            IApplicationRepository<WorkoutLog> repository, IApplicationRepository<Member> memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }
        public async Task<bool> Handle(CreateWorkoutLogCommand request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.MemberId, out Guid memberId)) return false;

            var member = await _memberRepository.GetAsync(memberId);

            if (member is null) return false;

            return await _repository.CreateAsync(WorkoutLog.Factory(
                memberId, request.ExerciseType, request.Sets,
                request.Reps, request.WeightKg, request.Notes));
        }
    }
}
