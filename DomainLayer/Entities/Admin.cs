
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Admin : User
    { 
        private Admin(string fullName, string username, string email, string passwordHash)
        {
            FullName = fullName;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Role = Role.Admin;
        }
        public AdminPermission AdminPermission { get; private set; }
        public static Admin Factory(string fullName, string username, string email, string passwordHash)
            => new Admin(fullName, username, email, passwordHash);

    }
}
