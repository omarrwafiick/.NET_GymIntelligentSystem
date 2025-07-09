 
namespace ApplicationLayer.Handlers.Feedbacks
{
    public class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommand, ServiceResult<bool>>
    {
        private readonly IApplicationRepository<Announcement> _repository;

        public CreateAnnouncementCommandHandler(IApplicationRepository<Announcement> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<bool>> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = Announcement.Factory(request.Title, request.Message, request.Audience);

            return await _repository.CreateAsync(announcement) ?
                ServiceResult<bool>.Success("Announcement was created successfully") :
                ServiceResult<bool>.Failure("Failed to create the announcement");
        }
    }
}
