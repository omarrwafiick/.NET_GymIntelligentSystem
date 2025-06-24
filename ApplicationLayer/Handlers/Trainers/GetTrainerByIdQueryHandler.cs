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

        public Task<GetTrainerDto> Handle(GetTrainerByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
