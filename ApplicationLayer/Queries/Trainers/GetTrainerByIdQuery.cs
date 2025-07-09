 
namespace ApplicationLayer.Queries.Trainers
{ 
    public record GetTrainerByIdQuery(string TrainerId) : IRequest<ServiceResult<GetTrainerDto>>;
}
