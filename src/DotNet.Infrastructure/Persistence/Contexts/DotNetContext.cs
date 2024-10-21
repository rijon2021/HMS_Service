using DotNet.ApplicationCore.Entities;


using Microsoft.EntityFrameworkCore;


namespace DotNet.Infrastructure.Persistence.Contexts
{
    public class DotNetContext(DbContextOptions<DotNetContext> options) : DbContext(options)
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<GlobalSetting> GlobalSettings { get; set; }
        public DbSet<NotificationArea> NotificationAreas { get; set; }
        public DbSet<SMSNotification> SMSNotifications { get; set; }
        public DbSet<PermissionUserRoleMap> PermissionUserRoleMaps { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Attachments> Attachments { get; set; }
 

  
    }
}
