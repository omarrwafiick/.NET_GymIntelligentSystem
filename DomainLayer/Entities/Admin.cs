using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Admin : User
    {
        private Admin(
            string fullName, string username, string email, string passwordHash, 
            ICollection<Permission> permissions) : this(fullName, username, email, passwordHash)
        {
            Permissions = permissions;
        }
        private Admin(string fullName, string username, string email, string passwordHash)
        {
            FullName = fullName;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
        }

        public ICollection<Permission> Permissions { get; private set; } = new List<Permission>();
        public static Admin Factory(string fullName, string username, string email, string passwordHash) 
            => new Admin(fullName, username, email, passwordHash);
        public static Admin Factory(string fullName, string username, string email, string passwordHash, ICollection<Permission> permissions)
            => new Admin(fullName, username, email, passwordHash, permissions);
        public void AddPermission(Permission permission)
        {
            Permissions.Add(permission);
        }
    }
}
