 

namespace DomainLayer.Entities
{
    public class MemberTrainer : MainEntity
    {
        private MemberTrainer() { }
        private MemberTrainer(Guid memberId, Guid trainerId) { 
            MemberId = memberId;
            TrainerId = trainerId;
            AssignedOn = DateTime.UtcNow;
        }
        public Guid MemberId { get; private set; }
        public virtual Member Member { get; set; } 
        public Guid TrainerId { get; private set; }
        public virtual Trainer Trainer { get; set; } 
        public DateTime AssignedOn { get; private set; } 
        public static MemberTrainer Factory(Guid memberId, Guid trainerId)
            => new MemberTrainer(memberId, trainerId);
    }
}
