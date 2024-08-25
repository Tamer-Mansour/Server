using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketAction> TicketActions { get; set; }
        public DbSet<TicketAttachment> TicketAttachments { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketCategoryAssignment> TicketCategoryAssignments { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }
        public DbSet<TicketHistory> TicketHistories { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TicketStatus>().HasData(
                new TicketStatus { StatusId = 1, StatusName = "Open" },
                new TicketStatus { StatusId = 2, StatusName = "Closed" }
             );

            modelBuilder.Entity<TicketPriority>().HasData(
                new TicketPriority { PriorityId = 1, PriorityName = "High" },
                new TicketPriority { PriorityId = 2, PriorityName = "Medium" },
                new TicketPriority { PriorityId = 3, PriorityName = "Low" }
             );

            modelBuilder.Entity<TicketCategory>().HasData(
                new TicketCategory { CategoryId = 1, CategoryName = "Technical Support" },
                new TicketCategory { CategoryId = 2, CategoryName = "Customer Service" },
                new TicketCategory { CategoryId = 3, CategoryName = "Billing and Payments" },
                new TicketCategory { CategoryId = 4, CategoryName = "Product Feedback" },
                new TicketCategory { CategoryId = 5, CategoryName = "Account Management" },
                new TicketCategory { CategoryId = 6, CategoryName = "Order Processing" },
                new TicketCategory { CategoryId = 7, CategoryName = "System Maintenance" },
                new TicketCategory { CategoryId = 8, CategoryName = "Security Issues" },
                new TicketCategory { CategoryId = 9, CategoryName = "Training and Documentation" },
                new TicketCategory { CategoryId = 10, CategoryName = "Compliance and Regulations" }
            );

            modelBuilder.Entity<TicketAction>().HasData(
                new TicketAction { ActionId = 1, ActionName = "Created" },
                new TicketAction { ActionId = 2, ActionName = "Assigned" },
                new TicketAction { ActionId = 3, ActionName = "In Progress" },
                new TicketAction { ActionId = 4, ActionName = "Resolved" },
                new TicketAction { ActionId = 5, ActionName = "Closed" },
                new TicketAction { ActionId = 6, ActionName = "Reopened" },
                new TicketAction { ActionId = 7, ActionName = "Escalated" },
                new TicketAction { ActionId = 8, ActionName = "On Hold" },
                new TicketAction { ActionId = 9, ActionName = "Awaiting Customer Response" },
                new TicketAction { ActionId = 10, ActionName = "Awaiting Internal Review" }
            );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" },
                new IdentityRole { Id = "3", Name = "Support", NormalizedName = "SUPPORT" }
            );

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "1",
                    UserName = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    EmailConfirmed = true
                },
                new User
                {
                    Id = "2",
                    UserName = "customer@example.com",
                    NormalizedUserName = "CUSTOMER@EXAMPLE.COM",
                    Email = "customer@example.com",
                    NormalizedEmail = "CUSTOMER@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Customer@123"),
                    EmailConfirmed = true
                },
                new User
                {
                    Id = "3",
                    UserName = "support@example.com",
                    NormalizedUserName = "SUPPORT@EXAMPLE.COM",
                    Email = "support@example.com",
                    NormalizedEmail = "SUPPORT@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Support@123"),
                    EmailConfirmed = true
                }
            );

            // Seed UserRoles
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "2", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "3", RoleId = "3" }  
            );

            // Configure Ticket entity
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.TicketAttachments)
                .WithOne(a => a.Ticket)
                .HasForeignKey(a => a.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.TicketCategoryAssignments)
                .WithOne(a => a.Ticket)
                .HasForeignKey(a => a.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.TicketComments)
                .WithOne(c => c.Ticket)
                .HasForeignKey(c => c.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.TicketHistories)
                .WithOne(h => h.Ticket)
                .HasForeignKey(h => h.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure TicketAction entity
            modelBuilder.Entity<TicketAction>()
                .HasMany(a => a.TicketHistories)
                .WithOne(h => h.TicketAction)
                .HasForeignKey(h => h.ActionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure TicketCategory entity
            modelBuilder.Entity<TicketCategory>()
                .HasMany(c => c.TicketCategoryAssignments)
                .WithOne(a => a.TicketCategory)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure TicketComment entity
            modelBuilder.Entity<TicketComment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure TicketHistory entity
            modelBuilder.Entity<TicketHistory>()
                .HasOne(h => h.User)
                .WithMany()
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TicketHistory>()
                .HasOne(h => h.TicketAction)
                .WithMany()
                .HasForeignKey(h => h.ActionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure TicketPriority entity
            modelBuilder.Entity<TicketPriority>()
                .HasMany(p => p.Tickets)
                .WithOne(t => t.TicketPriority)
                .HasForeignKey(t => t.PriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure TicketStatus entity
            modelBuilder.Entity<TicketStatus>()
                .HasMany(s => s.Tickets)
                .WithOne(t => t.TicketStatus)
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
