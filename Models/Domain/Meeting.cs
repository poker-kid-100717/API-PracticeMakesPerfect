namespace API.Models.Domain
{
    public class Meeting
    {
        public Guid Id { get; set; }
        public required string OrganizationName { get; set; }
        public required string Position { get; set; }
        public required bool IsRemote { get; set; }
        public required string PaymentType { get; set; }
        public required double RateHourlyOrSalary { get; set; }
        public required string POCPhone { get; set; }
        public required int Round { get; set; }
        public required DateTime InterviewDateAndTime { get; set; }

        // Foreign key for Contact
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
