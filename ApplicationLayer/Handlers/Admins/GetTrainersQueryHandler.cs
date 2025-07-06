using ApplicationLayer.Contracts; 
using ApplicationLayer.Dtos.Trainers;
using ApplicationLayer.Queries.Admins;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Admins
{
    public class GetTrainersQueryHandler : IRequestHandler<GetTrainersQuery, List<GetTrainerDto>>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public GetTrainersQueryHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTrainerDto>> Handle(GetTrainersQuery request, CancellationToken cancellationToken)
        {
            var trainers = await _repository.GetAllAsync();
            return trainers.Any() ? trainers.Select(
                t => new GetTrainerDto(t.FullName, t.Username, t.Email, t.Speciality)).ToList()
            : [];
        }
    }
}
