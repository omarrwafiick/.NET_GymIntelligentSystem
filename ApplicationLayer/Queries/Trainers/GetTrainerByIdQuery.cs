using ApplicationLayer.Dtos.Trainers;
using MediatR; 

namespace ApplicationLayer.Queries.Trainers
{ 
    public record GetTrainerByIdQuery(string TrainerId) : IRequest<GetTrainerDto>;
}
