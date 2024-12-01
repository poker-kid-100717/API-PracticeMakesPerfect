namespace API.Models.Domain
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? OrganizationName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? IsInterviewSchedule { get; set; }

        // One-to-One: Navigation property to the primary Meeting
        public Meeting? Meeting { get; set; }

        // One-to-Many: Navigation property for associated Meetings
        public ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    }
}
