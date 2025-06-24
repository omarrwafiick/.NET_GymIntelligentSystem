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

        public Task<bool> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
