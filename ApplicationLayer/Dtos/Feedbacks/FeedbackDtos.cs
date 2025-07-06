
using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Dtos.Feedbacks
{
    public record CreateFeedbackDto(
        [Required] string UserId, [Required] int Rating, [Required] string Comment, 
        [Required] TargetType TargetType, string TargetId
    );
    public record ContactSupportDto([Required] string Message, [Required] string Subject, [Required] string UserId);
    public record CreateAnnouncementDto([Required] string Title, [Required] string Message, [Required] AudienceType Audience);
    public record GetAnnouncementDto(string Title, string Message, DateTime SentAt);
     
}
