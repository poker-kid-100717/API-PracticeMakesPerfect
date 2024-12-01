using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: new Guid("7cd8b6c7-d892-45fa-8e7e-e8c7fa51c7c1"));

            migrationBuilder.DeleteData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: new Guid("9642178a-5a57-49a1-af4f-87d7a005b5dd"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("bddb92a0-4595-47ba-9006-a7c3547116e7"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("ddd3805e-6ea3-44f1-aa7b-411bc58b2e85"));

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "IsInterviewSchedule", "Name", "OrganizationName", "Phone" },
                values: new object[,]
                {
                    { new Guid("01d9519e-485b-4287-9599-8997e2a2f82c"), "bob.smith@innovatex.com", false, "Bob Smith", "InnovateX", "234-567-8901" },
                    { new Guid("2b41fac3-c947-4875-971f-b4c1bcdb0f05"), "alice.johnson@techcorp.com", true, "Alice Johnson", "TechCorp", "123-456-7890" }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "ContactId", "InterviewDateAndTime", "IsRemote", "OrganizationName", "POCPhone", "PaymentType", "Position", "PrimaryContactId", "RateHourlyOrSalary", "Round" },
                values: new object[,]
                {
                    { new Guid("15644572-e8d0-44e8-b6c4-8250e2b2a534"), null, new DateTime(2024, 12, 3, 20, 6, 12, 712, DateTimeKind.Local).AddTicks(4693), false, "InnovateX", "234-567-8901", "Hourly", "Frontend Developer", new Guid("01d9519e-485b-4287-9599-8997e2a2f82c"), 50.0, 1 },
                    { new Guid("751d5ae8-b7df-44e6-85e7-ae12138a8a20"), new Guid("2b41fac3-c947-4875-971f-b4c1bcdb0f05"), new DateTime(2024, 12, 2, 20, 6, 12, 708, DateTimeKind.Local).AddTicks(5483), true, "TechCorp", "123-456-7890", "Salary", "Software Engineer", null, 120000.0, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: new Guid("15644572-e8d0-44e8-b6c4-8250e2b2a534"));

            migrationBuilder.DeleteData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: new Guid("751d5ae8-b7df-44e6-85e7-ae12138a8a20"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("01d9519e-485b-4287-9599-8997e2a2f82c"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("2b41fac3-c947-4875-971f-b4c1bcdb0f05"));

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "IsInterviewSchedule", "Name", "OrganizationName", "Phone" },
                values: new object[,]
                {
                    { new Guid("bddb92a0-4595-47ba-9006-a7c3547116e7"), "bob.smith@innovatex.com", false, "Bob Smith", "InnovateX", "234-567-8901" },
                    { new Guid("ddd3805e-6ea3-44f1-aa7b-411bc58b2e85"), "alice.johnson@techcorp.com", true, "Alice Johnson", "TechCorp", "123-456-7890" }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "ContactId", "InterviewDateAndTime", "IsRemote", "OrganizationName", "POCPhone", "PaymentType", "Position", "PrimaryContactId", "RateHourlyOrSalary", "Round" },
                values: new object[,]
                {
                    { new Guid("7cd8b6c7-d892-45fa-8e7e-e8c7fa51c7c1"), null, new DateTime(2024, 12, 3, 20, 3, 23, 289, DateTimeKind.Local).AddTicks(5194), false, "InnovateX", "234-567-8901", "Hourly", "Frontend Developer", new Guid("bddb92a0-4595-47ba-9006-a7c3547116e7"), 50.0, 1 },
                    { new Guid("9642178a-5a57-49a1-af4f-87d7a005b5dd"), new Guid("ddd3805e-6ea3-44f1-aa7b-411bc58b2e85"), new DateTime(2024, 12, 2, 20, 3, 23, 286, DateTimeKind.Local).AddTicks(6546), true, "TechCorp", "123-456-7890", "Salary", "Software Engineer", null, 120000.0, 1 }
                });
        }
    }
}
