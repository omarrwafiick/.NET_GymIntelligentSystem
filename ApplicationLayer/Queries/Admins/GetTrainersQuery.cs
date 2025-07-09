
 
 

namespace ApplicationLayer.Queries.Admins
{ 
    public record GetTrainersQuery() : IRequest<ServiceResult<List<GetTrainerDto>>>;
}
