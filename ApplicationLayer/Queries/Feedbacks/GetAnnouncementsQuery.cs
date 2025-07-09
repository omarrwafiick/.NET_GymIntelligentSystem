
 

namespace ApplicationLayer.Queries.Feedbacks
{ 
    public record GetAnnouncementsQuery(string UserId, string AudienceType) : IRequest<ServiceResult<List<GetAnnouncementDto>>>;
}
