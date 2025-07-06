 
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Feedbacks;
using ApplicationLayer.Queries.Feedbacks;
using DomainLayer.Entities;
using DomainLayer.Enums;
using MediatR; 

namespace ApplicationLayer.Handlers.Feedbacks
{
    public class GetAnnouncementsQueryHandler : IRequestHandler<GetAnnouncementsQuery, List<GetAnnouncementDto>>
    {
        private readonly IApplicationRepository<Announcement> _repository;

        public GetAnnouncementsQueryHandler(IApplicationRepository<Announcement> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAnnouncementDto>> Handle(GetAnnouncementsQuery request, CancellationToken cancellationToken)
        {
            var type = request.AudienceType;
            var announcements = new List<Announcement>();
            switch (type)
            {
                case var a when a == AudienceType.Admins.ToString():
                    announcements = await _repository.GetAllAsync(x=>x.AudienceType == AudienceType.Admins);
                    break;
                case var a when a == AudienceType.Trainers.ToString():
                    announcements = await _repository.GetAllAsync(x => x.AudienceType == AudienceType.Trainers);
                    break;
                case var a when a == AudienceType.Members.ToString():
                    announcements = await _repository.GetAllAsync(x => x.AudienceType == AudienceType.Members);
                    break;
                default:
                    announcements = await _repository.GetAllAsync(x => x.AudienceType == AudienceType.All);
                    break;
            }
            return announcements.Any() ?
                announcements.Select(a => new GetAnnouncementDto(a.Title, a.Message, a.SentAt)).ToList()
                : [];
        }
    }
}
