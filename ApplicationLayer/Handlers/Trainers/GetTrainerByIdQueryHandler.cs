using ApplicationLayer.Contracts; 
using ApplicationLayer.Dtos.Trainers;
using ApplicationLayer.Queries.Trainers;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handler.Trainers
{
    public class GetTrainerByIdQueryHandler : IRequestHandler<GetTrainerByIdQuery, GetTrainerDto>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public GetTrainerByIdQueryHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public async Task<GetTrainerDto> Handle(GetTrainerByIdQuery request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.TrainerId, out Guid trainerId)) return null;

            var trainer = await _repository.GetAsync(trainerId);

            if (trainer is null) return null;

            return new GetTrainerDto(trainer.FullName, trainer.Username, trainer.Email, trainer.Speciality);
        }
    }
}
