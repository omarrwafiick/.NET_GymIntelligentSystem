using ApplicationLayer.Commands.Members;
using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using MediatR;
namespace ApplicationLayer.Handlers.Members
{
    public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommand, Guid>
    {
        private readonly IApplicationRepository<Member> _repository;

        public RegisterMemberCommandHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
        {
            //HASH PASSWORD
            var member = Member.Factory(
                request.FullName,
                request.Username,
                request.Email,
                request.Password, 
                request.HeightCm,
                request.WeightKg,
                request.Goal,
                request.DateOfBirth
            );

            _repository.CreateAsync(member);

            return member.Id;
        }
    }

}
