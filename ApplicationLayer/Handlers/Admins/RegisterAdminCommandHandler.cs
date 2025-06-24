using ApplicationLayer.Commands.Admins;
using ApplicationLayer.Contracts; 
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Admins
{
    internal class RegisterAdminCommandHandler : IRequestHandler<RegisterAdminCommand, Guid>
    {
        private readonly IApplicationRepository<Admin> _repository;

        public RegisterAdminCommandHandler(IApplicationRepository<Admin> repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //add default admin permissions
    }
}
