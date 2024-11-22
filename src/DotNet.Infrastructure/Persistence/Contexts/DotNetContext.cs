using DotNet.ApplicationCore.Entities;
using DotNet.ApplicationCore.Entities.HMS;
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

        // HMS
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Branch>  Branches { get; set; }
        public DbSet<Room>  Rooms { get; set; }
        public DbSet<Bed>  Beds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        

            base.OnModelCreating(modelBuilder);

            // Relationship: Hostel -> Branch
            modelBuilder.Entity<Branch>()
                .HasOne(b => b.Hostel) // A Branch belongs to one Hostel
                .WithMany(h => h.Branches) // A Hostel has many Branches
                .HasForeignKey(b => b.HostelId) // Foreign key in Branch table
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if Hostel is deleted

            // Relationship: Branch -> Room
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Branch) // A Room belongs to one Branch
                .WithMany(b => b.Rooms) // A Branch has many Rooms
                .HasForeignKey(r => r.BranchId) // Foreign key in Room table
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if Branch is deleted

            // Relationship: Room -> Bed
            modelBuilder.Entity<Bed>()
                .HasOne(b => b.Room) // A Bed belongs to one Room
                .WithMany(r => r.Beds) // A Room has many Beds
                .HasForeignKey(b => b.RoomId) // Foreign key in Bed table
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if Room is deleted
        }


    }
}
