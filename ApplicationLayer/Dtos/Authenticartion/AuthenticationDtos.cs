 
using System.ComponentModel.DataAnnotations; 

namespace ApplicationLayer.Dtos.Authenticartion
{
    public record LoginDto([EmailAddress] string Email, [Required] string Password); 
    public record GetUserInfoDto(string Email, string Username, string Fullname);
}
