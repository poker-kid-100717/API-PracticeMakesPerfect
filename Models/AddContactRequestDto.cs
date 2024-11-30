using API.Models.Domain;

namespace API.Models
{
    public class AddContactRequestDto
    {
        public required string Name { get; set; }
        public required string Position { get; set; }
        public required string OrganizationName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required bool IsInterviewSchedule { get; set; }
        public Meeting Meeting { get; set; }
    }
}
