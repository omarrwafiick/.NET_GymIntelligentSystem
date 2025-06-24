 
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Trainers;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Queries.WorkoutPlans
{
    public class GetWorkoutPlansHistoryQueryHandler : IRequestHandler<GetWorkoutPlansHistoryQuery, List<GetWorkoutPlansDto>>
    {
        private readonly IApplicationRepository<WorkoutPlan> _repository;

        public GetWorkoutPlansHistoryQueryHandler(IApplicationRepository<WorkoutPlan> repository)
        {
            _repository = repository;
        }

        public Task<List<GetWorkoutPlansDto>> Handle(GetWorkoutPlansHistoryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
