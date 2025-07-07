
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Recommendations;
using ApplicationLayer.Queries.Recommendations;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Recommendations
{
    public class GenerateSmartWorkoutPlanQueryHandler : IRequestHandler<GenerateSmartWorkoutPlanQuery, SmartWorkoutPlanDto>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GenerateSmartWorkoutPlanQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<SmartWorkoutPlanDto> Handle(GenerateSmartWorkoutPlanQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.MemberId, out Guid trainerId)) return null;

            var member = await _repository.GetAsync(trainerId);

            if (member is null) return null;
             
            throw new NotImplementedException();
        }
    }
}
