
using ApplicationLayer.Commands.Profiles;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Profiles
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, bool>
    {
        private readonly IApplicationRepository<User> _repository;

        public UpdateProfileCommandHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            Guid.TryParse(request.id, out Guid userId);

            if (userId.ToString() is null) return false;

            var user = await _repository.GetAsync(u => u.Id == userId);
            if (user == null) return false;

            user.ChangeUsername(request.Username);
            user.ChangeName(request.Fullname);

            return await _repository.UpdateAsync(user);
        }
    }
}
