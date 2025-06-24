 
using System.ComponentModel.DataAnnotations; 

namespace ApplicationLayer.Dtos.Profiles
{
    public record ChangePasswordDto([Required] string Email, [Required] string Password);
    public record UpdateProfileDtos([Required] string Fullname, [Required] string Username);
}
