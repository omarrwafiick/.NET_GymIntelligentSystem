using ApplicationLayer.Commands.Members;
using ApplicationLayer.Contracts;  
using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Handlers.Members
{
    public class CreateNutritionPlanCommandHandler : IRequestHandler<CreateNutritionPlanCommand, bool>
    {
        private readonly IApplicationRepository<NutritionPlan> _repository;

        public CreateNutritionPlanCommandHandler(IApplicationRepository<NutritionPlan> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(CreateNutritionPlanCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
