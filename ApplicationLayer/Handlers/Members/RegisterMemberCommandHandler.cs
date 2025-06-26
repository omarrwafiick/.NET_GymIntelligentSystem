using ApplicationLayer.Commands.Members;
using ApplicationLayer.Contracts;
using ApplicationLayer.Helpers;
using DomainLayer.Entities;
using MediatR;
namespace ApplicationLayer.Handlers.Members
{
    public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommand, Guid?>
    {
        private readonly IApplicationRepository<Member> _repository;

        public RegisterMemberCommandHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<Guid?> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
        { 
            var member = await _repository.GetAsync(u => u.Email == request.Email);

            if (member is not null)
                return null;

            var hashedPassword = SecurityHelpers.HashPassword(request.Password);

            member = Member.Factory(
                    request.FullName, request.Username, request.Email, hashedPassword,
                    request.HeightCm, request.WeightKg, request.Goal, request.DateOfBirth
            );

            var result = await _repository.CreateAsync(member);

            if (!result)
                return null; 

            return member.Id;
        }
    }

}
