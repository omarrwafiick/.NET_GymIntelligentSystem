

using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Members;
using ApplicationLayer.Queries.Members;
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Members
{
    public class GetMemberProgressReportQueryHandler : IRequestHandler<GetMemberProgressReportQuery, GetProgressReportDto>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GetMemberProgressReportQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public Task<GetProgressReportDto> Handle(GetMemberProgressReportQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
