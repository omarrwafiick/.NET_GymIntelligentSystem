using ApplicationLayer.Commands.Profiles;
using ApplicationLayer.Contracts;
using ApplicationLayer.Helpers;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Profiles
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IApplicationRepository<User> _repository;

        public ChangePasswordCommandHandler(IApplicationRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAsync(u => u.Email == request.Email);
            if (user == null) return false; 

            var newHashedPassword = SecurityHelpers.HashPassword(request.Password);
            user.ChangePassword(newHashedPassword);

            return await _repository.UpdateAsync(user);
        }
    }
}
