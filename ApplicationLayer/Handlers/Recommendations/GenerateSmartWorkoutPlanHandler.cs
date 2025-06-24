
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Recommendations;
using ApplicationLayer.Queries.Recommendations;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Recommendations
{
    public class GenerateSmartWorkoutPlanQueryHandler : IRequestHandler<GenerateSmartWorkoutPlanQuery, SmartWorkoutPlanDto>
    {
        private readonly IApplicationRepository<User> _repository;

        public GenerateSmartWorkoutPlanQueryHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public Task<SmartWorkoutPlanDto> Handle(GenerateSmartWorkoutPlanQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
