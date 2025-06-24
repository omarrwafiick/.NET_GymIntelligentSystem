

using ApplicationLayer.Commands.Trainers;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Trainers
{
    public class RegisterTrainerCommandHandler : IRequestHandler<RegisterTrainerCommand, Guid>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public RegisterTrainerCommandHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(RegisterTrainerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
