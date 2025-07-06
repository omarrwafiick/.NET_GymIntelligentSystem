using ApplicationLayer.Commands.Feedbacks;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;
 
namespace ApplicationLayer.Handlers.Feedbacks
{
    public class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommand, bool>
    {
        private readonly IApplicationRepository<Announcement> _repository;

        public CreateAnnouncementCommandHandler(IApplicationRepository<Announcement> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = Announcement.Factory(request.Title, request.Message, request.Audience);

            return await _repository.CreateAsync(announcement);
        }
    }
}
