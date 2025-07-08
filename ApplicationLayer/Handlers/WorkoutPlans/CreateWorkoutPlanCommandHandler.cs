using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Commands.WorkoutPlans
{
    public class CreateWorkoutPlanCommandHandler : IRequestHandler<CreateWorkoutPlanCommand, bool>
    {
        private readonly IApplicationRepository<WorkoutPlan> _repository;
        private readonly IApplicationRepository<Member> _memberRepository;
        private readonly IApplicationRepository<Trainer> _trainerRepository;
        public CreateWorkoutPlanCommandHandler(
            IApplicationRepository<WorkoutPlan> repository,
            IApplicationRepository<Member> memberRepository,
            IApplicationRepository<Trainer> trainerRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
            _trainerRepository = trainerRepository;
        }

        public async Task<bool> Handle(CreateWorkoutPlanCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var endDate = new DateTime(now.Year, now.Month, request.DurationInDays);
            if (!Guid.TryParse(request.MemberId, out Guid memberId)
                || !Guid.TryParse(request.TrainerId, out Guid trainerId)
                || (request.StartDate > now || endDate < request.StartDate)) return false;

            var member = await _memberRepository.GetAsync(memberId);
            var trainer = await _trainerRepository.GetAsync(trainerId);

            if (member is null || trainer is null) return false;

            return await _repository.CreateAsync(
                WorkoutPlan.Factory(memberId, trainerId, request.PlanType, 
                request.StartDate, request.DurationInDays, request.FocusArea)
            );
        }
    }
}
