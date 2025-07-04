﻿ 
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class Trainer : User
    {
        private Trainer(){}
        private Trainer(string fullName, string username, string email, string passwordHash, Speciality specialty) {
            FullName = fullName;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Speciality = specialty; 
            Role = Role.Trainer;
        }
        public Speciality Speciality { get; private set; }
        public virtual ICollection<MemberTrainer> MemberAssignments { get; private set; } = new List<MemberTrainer>();
        public static Trainer Factory(string fullName, string username, string email, string passwordHash, Speciality specialty) 
            => new Trainer(fullName, username, email, passwordHash, specialty);
    }
}
