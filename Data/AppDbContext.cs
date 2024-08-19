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
