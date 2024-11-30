namespace API.Models.Domain
{
    public class Contact
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string OrganizationName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required bool IsInterviewSchedule { get; set; }

        // Foreign key for Meeting
        public Guid MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}
