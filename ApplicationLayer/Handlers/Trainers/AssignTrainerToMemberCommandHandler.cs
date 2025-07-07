 
using ApplicationLayer.Commands.Trainers;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Trainers
{
    public class AssignTrainerToMemberCommandHandler : IRequestHandler<AssignTrainerToMemberCommand, bool>
    {
        private readonly IApplicationRepository<Trainer> _repository;
        private readonly IApplicationRepository<Member> _memberRepository;
        private readonly IApplicationRepository<MemberTrainer> _memberTrainerRepository;

        public AssignTrainerToMemberCommandHandler(
            IApplicationRepository<Trainer> repository,
            IApplicationRepository<Member> memberRepository,
            IApplicationRepository<MemberTrainer> memberTrainerRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
            _memberTrainerRepository = memberTrainerRepository;
        }

        public async Task<bool> Handle(AssignTrainerToMemberCommand request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.MemberId, out Guid memberId) ||
                Guid.TryParse(request.TrainerId, out Guid trainerId)) return false;

            var member = await _memberRepository.GetAsync(memberId);
            var trainer = await _repository.GetAsync(trainerId);
            var relationExists = await _memberTrainerRepository.GetAsync(
                m => m.TrainerId == trainerId && m.MemberId == memberId);

            if (member is null || trainer is null || relationExists is not null) return false;

            return await _memberTrainerRepository.CreateAsync(MemberTrainer.Factory(memberId, trainerId));

        }
    }
}
