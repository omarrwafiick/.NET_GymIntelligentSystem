 

namespace ApplicationLayer.Handler.Trainers
{
    public class GetTrainerByIdQueryHandler : IRequestHandler<GetTrainerByIdQuery, ServiceResult<GetTrainerDto>>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public GetTrainerByIdQueryHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<GetTrainerDto>> Handle(GetTrainerByIdQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.TrainerId, out Guid trainerId)) return ServiceResult<GetTrainerDto>.Failure("Invalid Id/s");

            var trainer = await _repository.GetAsync(trainerId);

            if (trainer is null) return ServiceResult<GetTrainerDto>.Failure("Trainer was not found");

            return ServiceResult<GetTrainerDto>.Success("",
                new GetTrainerDto(trainer.FullName, trainer.Username, trainer.Email, trainer.Speciality)); 
        }
    }
}
