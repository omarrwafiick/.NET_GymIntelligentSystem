

using ApplicationLayer.Commands.Members;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Members
{
    public class CreateWorkoutLogCommandHandler : IRequestHandler<CreateWorkoutLogCommand, bool>
    {
        private readonly IApplicationRepository<WorkoutLog> _repository;

        public CreateWorkoutLogCommandHandler(IApplicationRepository<WorkoutLog> repository)
        {
            _repository = repository;
        }
    
        public Task<bool> Handle(CreateWorkoutLogCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
