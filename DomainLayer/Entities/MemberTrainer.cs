 

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
        public Member Member { get; private set; } 
        public Guid TrainerId { get; private set; }
        public Trainer Trainer { get; private set; } 
        public DateTime AssignedOn { get; private set; } 
        public static MemberTrainer Factory(Guid memberId, Guid trainerId)
            => new MemberTrainer(memberId, trainerId);
    }
}
