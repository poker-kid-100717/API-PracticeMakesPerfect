using Microsoft.EntityFrameworkCore;
using API.Models.Domain;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-one relationship
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Meeting)
                .WithOne(m => m.Contact)
                .HasForeignKey<Contact>(c => c.MeetingId);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Contact)
                .WithOne(c => c.Meeting)
                .HasForeignKey<Meeting>(m => m.ContactId);
        }
    }
}
