 
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
            var goals = Enum.GetValues(typeof(Goal)).Cast<string>().ToArray();

            if (!goals.Any(a => a == request.Goal)) ServiceResult<bool>.Failure("Invalid goal");

            var member = await _repository.GetAsync(u => u.Email == request.Email || u.Username == u.Username);

            if (member is not null)
                return ServiceResult<Guid>.Failure("Member already exists with same email or username");

            if (request.DateOfBirth.Year > DateTime.UtcNow.Year)
                return ServiceResult<Guid>.Failure("Member BirthDate is incorrect");

            var hashedPassword = SecurityHelpers.HashPassword(request.Password);

            member = Member.Factory(
                    request.FullName, request.Username, request.Email, hashedPassword,
                    request.HeightCm, request.WeightKg, Enum.Parse<Goal>(request.Goal), request.DateOfBirth, 
                    request.IsMale ? Gender.MALE : Gender.FEMALE
            ); 

            return await _repository.CreateAsync(member) ?
                ServiceResult<Guid>.Success("Member was created successfully", member.Id) :
                ServiceResult<Guid>.Failure("Member could't be created");
        }
    }

}
