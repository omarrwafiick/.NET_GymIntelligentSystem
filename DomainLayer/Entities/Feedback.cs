﻿
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Feedback : MainEntity
    {
        private Feedback() { }

        private Feedback(Guid userId, int rating, string comment, TargetType targetType, Guid targetId)
        {
            UserId = userId;
            Rating = rating;
            Comment = comment;
            TargetType = targetType;
            TargetId = targetId;
            SubmittedAt = DateTime.UtcNow;
        }

        public Guid UserId { get; private set; }
        public virtual User User { get; private set; } 
        public int Rating { get; private set; } 
        public string Comment { get; private set; } 
        public TargetType TargetType { get; private set; }
        public Guid TargetId { get; private set; } 
        public DateTime SubmittedAt { get; private set; } 
        public static Feedback Factory(Guid userId, int rating, string comment, TargetType targetType, Guid targetId )
            => new Feedback(userId, rating, comment, targetType, targetId);
    }

}
