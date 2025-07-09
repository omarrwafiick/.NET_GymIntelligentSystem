 

namespace ApplicationLayer.Handler.Trainers
{
    public class CreateTrainerProgressReportCommandHandler : IRequestHandler<CreateTrainerProgressReportCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<Trainer> _repository;
        private readonly IApplicationRepository<Member> _memberRepository;
        private readonly IApplicationRepository<MemberTrainer> _memberTrainerRepository;
        private readonly IApplicationRepository<ProgressReport> _progressReportRepository;
        public CreateTrainerProgressReportCommandHandler(
            IApplicationRepository<Trainer> repository,
            IApplicationRepository<Member> memberRepository,
            IApplicationRepository<MemberTrainer> memberTrainerRepository,
            IApplicationRepository<ProgressReport> progressReportRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
            _memberTrainerRepository = memberTrainerRepository;
            _progressReportRepository = progressReportRepository;
        }

        public async Task<ServiceResult<bool>> Handle(CreateTrainerProgressReportCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid memberId)
                || !Guid.TryParse(request.TrainerId, out Guid trainerId)) return ServiceResult<bool>.Failure("Invalid Id/s");

            var member = await _memberRepository.GetAsync(memberId);
            var trainer = await _repository.GetAsync(trainerId);
            var relationExists = await _memberTrainerRepository.GetAsync(
                m => m.TrainerId == trainerId && m.MemberId == memberId);

            if (member is null || trainer is null || relationExists is null)
                return ServiceResult<bool>.Failure("Entities Data was not found completely");


            return await _progressReportRepository.CreateAsync(ProgressReport.Factory(
                    memberId, trainerId, request.WeightKg, request.BodyFatPercentage, request.MuscleMass, request.TrainerNotes
                )) ?
                ServiceResult<bool>.Success("Progress report was created successfully") :
                ServiceResult<bool>.Failure("Failed to create the progress report");
        }
    }
}
