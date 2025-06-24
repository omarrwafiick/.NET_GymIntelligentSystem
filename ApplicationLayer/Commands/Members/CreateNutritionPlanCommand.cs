
using MediatR;

namespace ApplicationLayer.Commands.Members
{
    public record CreateNutritionPlanCommand(
        string MemberId, int CaloriesPerDay, float ProteinGrams,
        float CarbsGrams, float FatsGrams, string PlanNotes
    ) : IRequest<bool>;
}
