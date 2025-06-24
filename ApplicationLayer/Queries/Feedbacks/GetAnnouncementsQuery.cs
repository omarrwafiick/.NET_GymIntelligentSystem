
using ApplicationLayer.Dtos.Feedbacks;
using MediatR; 

namespace ApplicationLayer.Queries.Feedbacks
{ 
    public record GetAnnouncementsQuery(string UserId) : IRequest<List<GetAnnouncementDto>>;
}
