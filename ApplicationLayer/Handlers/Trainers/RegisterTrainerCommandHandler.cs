 

namespace ApplicationLayer.Handler.Trainers
{
    public class RegisterTrainerCommandHandler : IRequestHandler<RegisterTrainerCommand, ServiceResult<Guid>>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public RegisterTrainerCommandHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<Guid>> Handle(RegisterTrainerCommand request, CancellationToken cancellationToken)
        {
            var trainer = await _repository.GetAsync(u => u.Email == request.Email);

            if (trainer is not null)
                return ServiceResult<Guid>.Failure("Trainer was not found");

            var hashedPassword = SecurityHelpers.HashPassword(request.Password);

            trainer = Trainer.Factory(
                    request.FullName, request.Username, request.Email, 
                    hashedPassword,  request.Specialty
            ); 

            return await _repository.CreateAsync(trainer) ?
                ServiceResult<Guid>.Success("Trainer was created successfully", trainer.Id) :
                ServiceResult<Guid>.Failure("Failed to create trainer");
            
        }
    }
}
