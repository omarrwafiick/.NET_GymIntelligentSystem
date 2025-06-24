 
using ApplicationLayer.Commands.Trainers;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Trainers
{
    public class AssignTrainerToMemberCommandHandler : IRequestHandler<AssignTrainerToMemberCommand, bool>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public AssignTrainerToMemberCommandHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(AssignTrainerToMemberCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
