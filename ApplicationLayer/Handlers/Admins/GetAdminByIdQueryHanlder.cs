using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Admins;
using ApplicationLayer.Queries.Admins;
using DomainLayer.Entities;
using MediatR; 

namespace ApplicationLayer.Handlers.Admins
{
    public class GetAdminByIdQueryHanlder : IRequestHandler<GetAdminByIdQuery, GetAdminDto>
    {
        private readonly IApplicationRepository<Admin> _repository;

        public GetAdminByIdQueryHanlder(IApplicationRepository<Admin> repository)
        {
            _repository = repository;
        }

        public async Task<GetAdminDto> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
