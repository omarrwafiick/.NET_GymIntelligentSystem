using ApplicationLayer.Dtos.Members; 
using MediatR; 

namespace ApplicationLayer.Queries.Trainers
{ 
    public record GetAssignedMembersQuery(string TrainerId) : IRequest<List<GetMemeberDto>>;
}
