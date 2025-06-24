
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

        public Task<bool> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
