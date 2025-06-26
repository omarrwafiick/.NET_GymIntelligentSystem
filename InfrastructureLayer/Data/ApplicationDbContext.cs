using DomainLayer.Entities;
using DomainLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }          
        public DbSet<Admin> Admins { get; set; }   
        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<MemberTrainer> MemberTrainers { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<WorkoutLog> WorkoutLogs { get; set; }
        public DbSet<NutritionPlan> NutritionPlans { get; set; } 
        public DbSet<ProgressReport> ProgressReports { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SupportMessage> SupportMessages { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<AdminPermission> AdminPermissions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<PaymentHistory> PaymentHistory { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Config
            modelBuilder.Entity<User>().UseTptMappingStrategy();
            modelBuilder.Entity<MemberTrainer>().HasKey(k => new { k.Id, k.MemberId, k.TrainerId });
            modelBuilder.Entity<AdminPermission>().HasKey(k => new { k.Id, k.AdminId, k.PermissionId});
            #endregion

            #region Seeding
            modelBuilder.Entity<Permission>().HasData(
                [
                    Permission.Factory(PermissionType.Read),
                    Permission.Factory(PermissionType.Delete),
                    Permission.Factory(PermissionType.Update),
                    Permission.Factory(PermissionType.Create),
                ]
            );
            #endregion
            
        }
    }
}
