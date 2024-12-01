namespace API.Models.Dtos.Contact
{
    public class UpdateContactRequestDto
    {
        public string? Name { get; set; }
        public string? OrganizationName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? IsInterviewSchedule { get; set; }

    }
}
