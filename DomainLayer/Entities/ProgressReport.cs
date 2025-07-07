 

namespace DomainLayer.Entities
{
    public class ProgressReport : MainEntity
    {
        private ProgressReport() { }
        private ProgressReport(
            Guid memberId, Guid trainerId, float weightKg, float bodyFatPercentage,
            float muscleMass, string trainerNotes) 
        { 
            MemberId = memberId;
            TrainerId = trainerId;
            WeightKg = weightKg;
            BodyFatPercentage = bodyFatPercentage;
            MuscleMass = muscleMass;
            TrainerNotes = trainerNotes;
            RecordedOn = DateTime.UtcNow;
        }
        public Guid MemberId { get; private set; }
        public virtual Member Member { get; private set; }
        public Guid TrainerId { get; private set; }
        public virtual Trainer Trainer { get; private set; }
        public DateTime RecordedOn { get; private set; }
        public float WeightKg { get; private set; }
        public float BodyFatPercentage { get; private set; }
        public float MuscleMass { get; private set; } 
        public string TrainerNotes { get; private set; }
        public static ProgressReport Factory(
            Guid memberId, Guid trainerId ,float weightKg, float bodyFatPercentage,
            float muscleMass, string trainerNotes)
            => new ProgressReport(memberId, trainerId, weightKg, bodyFatPercentage, muscleMass, trainerNotes);
    }
}
