 
using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Feedbacks;
using ApplicationLayer.Queries.Feedbacks;
using DomainLayer.Entities;
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

        public Task<List<GetAnnouncementDto>> Handle(GetAnnouncementsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
