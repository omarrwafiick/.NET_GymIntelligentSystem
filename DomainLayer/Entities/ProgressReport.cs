 

namespace DomainLayer.Entities
{
    public class ProgressReport : MainEntity
    {
        private ProgressReport() { }
        private ProgressReport(
            Guid memberId, float weightKg, float bodyFatPercentage,
            float muscleMass, string trainerNotes) 
        { 
            MemberId = memberId;
            WeightKg = weightKg;
            BodyFatPercentage = bodyFatPercentage;
            MuscleMass = muscleMass;
            TrainerNotes = trainerNotes;
            RecordedOn = DateTime.UtcNow;
        }
        public Guid MemberId { get; private set; }
        public Member Member { get; private set; } 
        public DateTime RecordedOn { get; private set; }
        public float WeightKg { get; private set; }
        public float BodyFatPercentage { get; private set; }
        public float MuscleMass { get; private set; } 
        public string TrainerNotes { get; private set; }
        public static ProgressReport Factory(
            Guid memberId, float weightKg, float bodyFatPercentage,
            float muscleMass, string trainerNotes)
            => new ProgressReport(memberId, weightKg, bodyFatPercentage, muscleMass, trainerNotes);
    }
}
