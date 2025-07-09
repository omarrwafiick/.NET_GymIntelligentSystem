 

namespace ApplicationLayer.Queries.Trainers
{ 
    public record GetAssignedMembersQuery(string TrainerId) : IRequest<ServiceResult<List<GetMemeberDto>>>;
}
