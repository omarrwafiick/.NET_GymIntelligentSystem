 
namespace ApplicationLayer.Handler.Trainers
{
    public class AssignTrainerToMemberCommandHandler : IRequestHandler<AssignTrainerToMemberCommand, ServiceResult<bool>>
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

        public async Task<ServiceResult<bool>> Handle(AssignTrainerToMemberCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid memberId)
                || !Guid.TryParse(request.TrainerId, out Guid trainerId)) return ServiceResult<bool>.Failure("Invalid Id/s");

            var member = await _memberRepository.GetAsync(memberId);
            var trainer = await _repository.GetAsync(trainerId);
            var relationExists = await _memberTrainerRepository.GetAsync(
                m => m.TrainerId == trainerId && m.MemberId == memberId);

            if (member is null || trainer is null)  
                return ServiceResult<bool>.Failure("Entities Data was not found completely");

            if (relationExists is not null)
                return ServiceResult<bool>.Failure("Trainer already assigned to this member");

            return await _memberTrainerRepository.CreateAsync(MemberTrainer.Factory(memberId, trainerId)) ?
                ServiceResult<bool>.Success("Trainer was assigned to member successfully") :
                ServiceResult<bool>.Failure("Failed to assigned trainer to member"); 
        }
    }
}
