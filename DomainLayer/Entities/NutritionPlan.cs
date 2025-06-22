 
namespace DomainLayer.Entities
{
    public class NutritionPlan : MainEntity
    {
        private NutritionPlan() { }
        private NutritionPlan(
            Guid memberId, int caloriesPerDay, float proteinGrams,
            float carbsGrams, float fatsGrams, string planNotes) 
        {
            MemberId = memberId;
            CaloriesPerDay = caloriesPerDay;
            ProteinGrams = proteinGrams;
            CarbsGrams = carbsGrams;
            FatsGrams = fatsGrams;
            PlanNotes = planNotes;
            AssignedOn = DateTime.UtcNow;
        }
        public Guid MemberId { get; private set; }
        public Member Member { get; private set; } 
        public DateTime AssignedOn { get; private set; }
        public int CaloriesPerDay { get; private set; }
        public float ProteinGrams { get; private set; }
        public float CarbsGrams { get; private set; }
        public float FatsGrams { get; private set; } 
        public string PlanNotes { get; private set; }
        public static NutritionPlan Factory(Guid memberId, int caloriesPerDay, float proteinGrams,
            float carbsGrams, float fatsGrams, string planNotes)
            => new NutritionPlan(memberId, caloriesPerDay, proteinGrams, carbsGrams, fatsGrams, planNotes);
    }
}
