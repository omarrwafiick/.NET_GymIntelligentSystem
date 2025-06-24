
using ApplicationLayer.Dtos.Trainers;
using MediatR;
 

namespace ApplicationLayer.Queries.Admins
{ 
    public record GetTrainersQuery() : IRequest<List<GetTrainerDto>>;
}
