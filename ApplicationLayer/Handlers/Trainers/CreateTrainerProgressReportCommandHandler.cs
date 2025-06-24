
using ApplicationLayer.Commands.Trainers;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Trainers
{
    public class CreateTrainerProgressReportCommandHandler : IRequestHandler<CreateTrainerProgressReportCommand, bool>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public CreateTrainerProgressReportCommandHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(CreateTrainerProgressReportCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
