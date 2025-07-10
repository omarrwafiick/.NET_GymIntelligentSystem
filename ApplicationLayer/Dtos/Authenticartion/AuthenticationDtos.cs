﻿  

namespace ApplicationLayer.Dtos.Authenticartion
{
    public record LoginDto(
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        string Email,

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        string Password
    ); 
    public record GetUserInfoDto(string Email, string Username, string Fullname);
}
