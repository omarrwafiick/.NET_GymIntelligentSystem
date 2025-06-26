
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Permission : MainEntity
    {
        private Permission(){}
        private Permission(PermissionType permissionName)
        {
            PermissionName = permissionName; 
        }
        public PermissionType PermissionName { get; private set; } 
        public virtual AdminPermission AdminPermission { get; private set; }
        public static Permission Factory(PermissionType permissionName)
            => new Permission(permissionName);
    }
}
