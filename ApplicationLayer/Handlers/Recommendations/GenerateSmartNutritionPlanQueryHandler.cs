using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos.Recommendations;
using ApplicationLayer.Queries.Recommendations;
using DomainLayer.Entities;
using DomainLayer.Enums;
using MediatR;

namespace ApplicationLayer.Handlers.Recommendations
{
    public class GenerateSmartNutritionPlanQueryHandler : IRequestHandler<GenerateSmartNutritionPlanQuery, SmartNutritionPlanDto>
    {
        private readonly IApplicationRepository<Member> _repository;

        public GenerateSmartNutritionPlanQueryHandler(IApplicationRepository<Member> repository)
        {
            _repository = repository;
        }
 
        public async Task<SmartNutritionPlanDto> Handle(GenerateSmartNutritionPlanQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.MemberId, out Guid trainerId)) return null;

            var member = await _repository.GetAsync(trainerId);

            if (member is null) return null;

            float bmr = Bmr(
                member.WeightKg, member.HeightCm, GetAge(member.DateOfBirth), 
                member.Gender == Gender.MALE ? true : false); 

            float tdee = bmr * 1.55f;
            int calories = member.Goal switch
            {
                Goal.LOSE_WEIGHT => (int)(tdee - 500),
                Goal.BUILD_MUSCLE => (int)(tdee + 300),
                Goal.INCREASE_STRENGTH => (int)(tdee + 200),
                _ => (int)tdee
            };

            float pRatio = 0.30f, cRatio = 0.50f, fRatio = 0.20f;
            float protein = (calories * pRatio) / 4f;
            float carbs = (calories * cRatio) / 4f;
            float fats = (calories * fRatio) / 9f;

            string notes = $"Goal: {member.Goal}. Maintain {calories} kcal/day with 30/50/20 macro split.";

            return new SmartNutritionPlanDto(
                calories,
                protein,
                carbs,
                fats,
                notes,
                30,
                DateTime.Today
            );
        }

        private float Bmr(float weightKg, float heightCm, int ageYears, bool isMale)
        {
            return isMale
                ? 10 * weightKg + 6.25f * heightCm - 5 * ageYears + 5
                : 10 * weightKg + 6.25f * heightCm - 5 * ageYears - 161;
        }
    
        private int GetAge(DateOnly date)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);  

            return today.Year - date.Year;
        }
    }
}
