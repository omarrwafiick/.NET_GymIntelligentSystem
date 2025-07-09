 
namespace ApplicationLayer.Handlers.Members
{
    public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommand, ServiceResult<Guid>>
    {
        private readonly IApplicationRepository<Member> _repository;

        public RegisterMemberCommandHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<Guid>> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
        { 
            var member = await _repository.GetAsync(u => u.Email == request.Email);

            if (member is not null)
                return ServiceResult<Guid>.Failure("Member was not found");

            var hashedPassword = SecurityHelpers.HashPassword(request.Password);

            member = Member.Factory(
                    request.FullName, request.Username, request.Email, hashedPassword,
                    request.HeightCm, request.WeightKg, request.Goal, request.DateOfBirth, 
                    request.IsMale ? Gender.MALE : Gender.FEMALE
            ); 

            return await _repository.CreateAsync(member) ?
                ServiceResult<Guid>.Success("Member was created successfully", member.Id) :
                ServiceResult<Guid>.Failure("Member could't be created");
        }
    }

}
