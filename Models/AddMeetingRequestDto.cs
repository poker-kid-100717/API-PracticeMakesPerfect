using API.Models.Domain;

namespace API.Models
{
    public class AddMeetingRequestDto
    {
        public string? OrganizationName { get; set; }
        public string? Position { get; set; }
        public bool? IsRemote { get; set; }
        public string? PaymentType { get; set; }
        public double? RateHourlyOrSalary { get; set; }
        public string? POCPhone { get; set; }
        public int? Round { get; set; }
        public DateTime? InterviewDateAndTime { get; set; }

        // One-to-One: Foreign key for the Contact associated with this Meeting
        public Guid? ContactId { get; set; }
        public Contact? Contact { get; set; }

        // One-to-Many: Foreign key for the primary Contact associated with this Meeting
        public Guid? PrimaryContactId { get; set; }
        public Contact? PrimaryContact { get; set; }
    }
}
