using ApplicationLayer.Commands.Trainers;
using ApplicationLayer.Contracts;
using ApplicationLayer.Helpers;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Trainers
{
    public class RegisterTrainerCommandHandler : IRequestHandler<RegisterTrainerCommand, Guid?>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public RegisterTrainerCommandHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public async Task<Guid?> Handle(RegisterTrainerCommand request, CancellationToken cancellationToken)
        {
            var trainer = await _repository.GetAsync(u => u.Email == request.Email);

            if (trainer is not null)
                return null;

            var hashedPassword = SecurityHelpers.HashPassword(request.Password);

            trainer = Trainer.Factory(
                    request.FullName, request.Username, request.Email, 
                    hashedPassword,  request.Specialty
            );

            var result = await _repository.CreateAsync(trainer);

            if (!result)
                return null;

            return trainer.Id;
        }
    }
}
