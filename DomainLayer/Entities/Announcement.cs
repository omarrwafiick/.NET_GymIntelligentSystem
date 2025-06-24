using DomainLayer.Enums; 

namespace DomainLayer.Entities
{
    public class Announcement : MainEntity
    {
        private Announcement() { }

        private Announcement(string title, string message, AudienceType audience)
        {
            Title = title;
            Message = message;
            AudienceType = audience;
            SentAt = DateTime.UtcNow;
        }

        public string Title { get; private set; }
        public string Message { get; private set; }
        public AudienceType AudienceType { get; private set; }  
        public DateTime SentAt { get; private set; }

        public static Announcement Factory(string title, string message, AudienceType audience)
            => new Announcement(title, message, audience);
    }
}
