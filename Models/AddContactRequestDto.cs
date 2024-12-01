using API.Models.Domain;

namespace API.Models
{
    public class AddContactRequestDto
    {
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
