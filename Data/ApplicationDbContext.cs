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

            // One-to-One: Meeting -> Contact
            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Contact)
                .WithOne(c => c.Meeting)
                .HasForeignKey<Meeting>(m => m.ContactId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many: Contact -> Meetings
            modelBuilder.Entity<Contact>()
                .HasMany(c => c.Meetings)
                .WithOne(m => m.PrimaryContact)
                .HasForeignKey(m => m.PrimaryContactId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            //SeedData(modelBuilder);
        }

        //private void SeedData(ModelBuilder modelBuilder)
        //{
        //    // Contacts
        //    var contact1 = new Contact
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Alice Johnson",
        //        OrganizationName = "TechCorp",
        //        Email = "alice.johnson@techcorp.com",
        //        Phone = "123-456-7890",
        //        IsInterviewSchedule = true
        //    };

        //    var contact2 = new Contact
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Bob Smith",
        //        OrganizationName = "InnovateX",
        //        Email = "bob.smith@innovatex.com",
        //        Phone = "234-567-8901",
        //        IsInterviewSchedule = false
        //    };

        //    modelBuilder.Entity<Contact>().HasData(contact1, contact2);

        //    // Meetings
        //    var meeting1 = new Meeting
        //    {
        //        Id = Guid.NewGuid(),
        //        OrganizationName = "TechCorp",
        //        Position = "Software Engineer",
        //        IsRemote = true,
        //        PaymentType = "Salary",
        //        RateHourlyOrSalary = 120000,
        //        POCPhone = "123-456-7890",
        //        Round = 1,
        //        InterviewDateAndTime = DateTime.Now.AddDays(2),
        //        ContactId = contact1.Id // One-to-one relationship
        //    };

        //    var meeting2 = new Meeting
        //    {
        //        Id = Guid.NewGuid(),
        //        OrganizationName = "InnovateX",
        //        Position = "Frontend Developer",
        //        IsRemote = false,
        //        PaymentType = "Hourly",
        //        RateHourlyOrSalary = 50.00,
        //        POCPhone = "234-567-8901",
        //        Round = 1,
        //        InterviewDateAndTime = DateTime.Now.AddDays(3),
        //        PrimaryContactId = contact2.Id // One-to-many relationship
        //    };

        //    modelBuilder.Entity<Meeting>().HasData(meeting1, meeting2);
        //}
    }
}
