using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationForLatest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: new Guid("88f6ce53-73d2-45ce-bbeb-e92edaed3199"));

            migrationBuilder.DeleteData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: new Guid("e0fabd37-2843-4bd9-876d-33e263faaf02"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("3456881f-9bb2-45e1-967e-0ea84e39bbf6"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("c380f320-ef9e-464e-ab66-ac06f45b9657"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("3456881f-9bb2-45e1-967e-0ea84e39bbf6"), "alice.johnson@techcorp.com", true, "Alice Johnson", "TechCorp", "123-456-7890" },
                    { new Guid("c380f320-ef9e-464e-ab66-ac06f45b9657"), "bob.smith@innovatex.com", false, "Bob Smith", "InnovateX", "234-567-8901" }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "ContactId", "InterviewDateAndTime", "IsRemote", "OrganizationName", "POCPhone", "PaymentType", "Position", "PrimaryContactId", "RateHourlyOrSalary", "Round" },
                values: new object[,]
                {
                    { new Guid("88f6ce53-73d2-45ce-bbeb-e92edaed3199"), new Guid("3456881f-9bb2-45e1-967e-0ea84e39bbf6"), new DateTime(2024, 12, 2, 20, 2, 9, 70, DateTimeKind.Local).AddTicks(6846), true, "TechCorp", "123-456-7890", "Salary", "Software Engineer", null, 120000.0, 1 },
                    { new Guid("e0fabd37-2843-4bd9-876d-33e263faaf02"), null, new DateTime(2024, 12, 3, 20, 2, 9, 72, DateTimeKind.Local).AddTicks(8150), false, "InnovateX", "234-567-8901", "Hourly", "Frontend Developer", new Guid("c380f320-ef9e-464e-ab66-ac06f45b9657"), 50.0, 1 }
                });
        }
    }
}
