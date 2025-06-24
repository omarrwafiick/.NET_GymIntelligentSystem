using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Trainers;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Queries.WorkoutPlans
{
    public class GetWorkoutPlansQueryHandler : IRequestHandler<GetWorkoutPlansQuery, List<GetWorkoutPlansDto>>
    {
        private readonly IApplicationRepository<WorkoutPlan> _repository;

        public GetWorkoutPlansQueryHandler(IApplicationRepository<WorkoutPlan> repository)
        {
            _repository = repository;
        }

        public Task<List<GetWorkoutPlansDto>> Handle(GetWorkoutPlansQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
