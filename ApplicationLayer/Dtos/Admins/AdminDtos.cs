 
namespace ApplicationLayer.Dtos.Admins
{
    public record AddPermissionDto(
        [Required(ErrorMessage = "PermissionId is required.")] string PermissionId,
        [Required(ErrorMessage = "AdminId is required.")] string AdminId
    );

    public record RegisterAdminDto(
        [Required(ErrorMessage = "Full name is required.")]
        [MinLength(3, ErrorMessage = "Full name must be at least 3 characters long.")]
        string FullName, 

        [Required(ErrorMessage = "Username is required.")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters long.")]
        string Username, 

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        string Email, 

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        string Password
    );
    public record GetPermissionDto(Guid Id, string PermissionName);
    public record GetAdminDto(string FullName, string Username, string Emai);
}
