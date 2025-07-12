  

namespace ApplicationLayer.Dtos.Feedbacks
{
    public record CreateFeedbackDto(
        [Required(ErrorMessage = "User ID is required.")]
        string UserId,

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        int Rating,

        [Required(ErrorMessage = "Comment is required.")]
        [MinLength(5, ErrorMessage = "Comment must be at least 5 characters long.")]
        string Comment,

        [Required(ErrorMessage = "Target type is required.")]
        string TargetType, 
        string TargetId  
    );
    public record ContactSupportDto(
        [Required(ErrorMessage = "Support message is required.")]
        [MinLength(10, ErrorMessage = "Message must be at least 10 characters long.")]
        string Message,

        [Required(ErrorMessage = "Subject is required.")]
        string Subject,

        [Required(ErrorMessage = "User ID is required.")]
        string UserId
    );

    public record CreateAnnouncementDto(
        [Required(ErrorMessage = "Title is required.")]
        [MinLength(5, ErrorMessage = "Title must be at least 5 characters long.")]
        string Title,

        [Required(ErrorMessage = "Message is required.")]
        [MinLength(10, ErrorMessage = "Message must be at least 10 characters long.")]
        string Message,

        [Required(ErrorMessage = "Audience type is required.")]
        string Audience
    );
    public record GetAnnouncementDto(string Title, string Message, DateTime SentAt);
     
}
