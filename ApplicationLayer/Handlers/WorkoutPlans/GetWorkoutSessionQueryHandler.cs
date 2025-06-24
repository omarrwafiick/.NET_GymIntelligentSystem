 
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Trainers;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Queries.WorkoutPlans
{
    public class GetWorkoutSessionsQueryHandler : IRequestHandler<GetWorkoutSessionsQuery, List<GetWorkoutSessionDto>>
    {
        private readonly IApplicationRepository<WorkoutSession> _repository;

        public GetWorkoutSessionsQueryHandler(IApplicationRepository<WorkoutSession> repository)
        {
            _repository = repository;
        }

        public Task<List<GetWorkoutSessionDto>> Handle(GetWorkoutSessionsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
