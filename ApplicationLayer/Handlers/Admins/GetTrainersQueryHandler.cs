 
namespace ApplicationLayer.Handlers.Admins
{
    public class GetTrainersQueryHandler : IRequestHandler<GetTrainersQuery, ServiceResult<List<GetTrainerDto>>>
    {
        private readonly IApplicationRepository<Trainer> _repository;

        public GetTrainersQueryHandler(IApplicationRepository<Trainer> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<List<GetTrainerDto>>> Handle(GetTrainersQuery request, CancellationToken cancellationToken)
        {
            var trainers = await _repository.GetAllAsync();

            return trainers.Any() ?
                ServiceResult< List < GetTrainerDto >>.Success("",
                      trainers.Select(
                        t => new GetTrainerDto(t.FullName, t.Username, t.Email, t.Speciality)).ToList()
                ) :
                ServiceResult< List < GetTrainerDto >>.Failure("No trainer was found");  
        }
    }
}
