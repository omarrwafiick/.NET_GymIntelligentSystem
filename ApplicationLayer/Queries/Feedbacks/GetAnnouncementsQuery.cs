
using ApplicationLayer.Dtos.Feedbacks;
using DomainLayer.Enums;
using MediatR; 

namespace ApplicationLayer.Queries.Feedbacks
{ 
    public record GetAnnouncementsQuery(string UserId, string AudienceType) : IRequest<List<GetAnnouncementDto>>;
}
