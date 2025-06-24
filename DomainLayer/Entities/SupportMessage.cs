 

namespace DomainLayer.Entities
{
    public class SupportMessage : MainEntity
    {
        private SupportMessage() { }
        private SupportMessage(string message, string subject, Guid userId) {
            Message = message;
            Subject = subject;
            UserId = userId;
            SentAt = DateTime.UtcNow;
        }

        public string Message { get; private set; }
        public string Subject { get; private set; } 
        public Guid UserId { get; private set; }
        public virtual User User { get; private set; }
        public DateTime SentAt { get; private set; }

        public static SupportMessage Factory(string message, string subject, Guid userId)
            => new SupportMessage(message, subject, userId);
    }
}
