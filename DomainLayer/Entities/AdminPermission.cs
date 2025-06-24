  
namespace DomainLayer.Entities
{
    public class AdminPermission : MainEntity
    {
        private AdminPermission() { }
        private AdminPermission(Guid adminId, Guid permissionId) { 
            AdminId = adminId;
            PermissionId = permissionId;
        }
        public Guid AdminId { get; private set; }
        public Admin Admin { get; private set; }
        public Guid PermissionId { get; private set; }
        public Permission Permission { get; private set; }
        public static AdminPermission Factory(Guid adminId, Guid permissionId)
            => new AdminPermission(adminId, permissionId);
    }
}
