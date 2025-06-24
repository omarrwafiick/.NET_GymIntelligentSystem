 
namespace DomainLayer.Entities
{
    public class Permission : MainEntity
    {
        private Permission(){}
        private Permission(string permissionName)
        {
            PermissionName = permissionName; 
        }
        public string PermissionName { get; private set; } 
        public AdminPermission AdminPermission { get; private set; }
        public static Permission Factory(string permissionName)
            => new Permission(permissionName);
    }
}
