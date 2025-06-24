
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Members;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Members
{
    public class GetWorkoutLogsQueryHandler : IRequestHandler<GetWorkoutLogsQuery, List<GetWorkoutLogsDto>>
    {
        private readonly IApplicationRepository<WorkoutLog> _repository;

        public GetWorkoutLogsQueryHandler(IApplicationRepository<WorkoutLog> repository)
        {
            _repository = repository;
        }
    
        public Task<List<GetWorkoutLogsDto>> Handle(GetWorkoutLogsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
