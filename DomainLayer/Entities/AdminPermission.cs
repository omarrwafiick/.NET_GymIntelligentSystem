  
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
        public virtual Admin Admin { get; private set; }
        public Guid PermissionId { get; private set; }
        public virtual Permission Permission { get; private set; }
        public static AdminPermission Factory(Guid adminId, Guid permissionId)
            => new AdminPermission(adminId, permissionId);
    }
}
