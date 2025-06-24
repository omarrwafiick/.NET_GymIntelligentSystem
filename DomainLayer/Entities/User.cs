using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class User : MainEntity
    {
        public User(){ }
        public string FullName { get; protected set; } 
        public string Username { get; protected set; }
        public string Email { get; protected set; } 
        public string PasswordHash { get; protected set; }
        public string ResetToken { get; protected set; } = string.Empty;
        public DateTime ResetTokenExpiresIn { get; protected set; } = DateTime.UtcNow;
        public Role Role { get; protected set; }
        public DateTime JoinedAt { get; protected set; } = DateTime.UtcNow; 
        public ICollection<SupportMessage> SupportMessages { get; private set; } = new List<SupportMessage>();
        public ICollection<Feedback> Feedbacks { get; private set; } = new List<Feedback>();

    }
}
