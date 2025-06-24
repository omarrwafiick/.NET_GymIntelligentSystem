

using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Dtos.Admins
{
    public record AddPermissionDto([Required] string PermissionId, [Required] string AdminId);
    public record RegisterAdminDto(
        [Required] string FullName, [Required] string Username, 
        [Required] string Email, [Required] string Password
    );
    public record GetPermissionDto(Guid Id, string PermissionName);
    public record GetAdminDto(string FullName, string Username, string Emai);
}
