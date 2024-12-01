using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInterviewSchedule = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemote = table.Column<bool>(type: "bit", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateHourlyOrSalary = table.Column<double>(type: "float", nullable: true),
                    POCPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Round = table.Column<int>(type: "int", nullable: true),
                    InterviewDateAndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrimaryContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Meetings_Contacts_PrimaryContactId",
                        column: x => x.PrimaryContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "IsInterviewSchedule", "Name", "OrganizationName", "Phone" },
                values: new object[,]
                {
                    { new Guid("5eb949eb-58cb-48bc-b978-df33e9942c61"), "alice.johnson@techcorp.com", true, "Alice Johnson", "TechCorp", "123-456-7890" },
                    { new Guid("f3751eb7-3533-4911-bfef-c8ea4254e5b8"), "bob.smith@innovatex.com", false, "Bob Smith", "InnovateX", "234-567-8901" }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "ContactId", "InterviewDateAndTime", "IsRemote", "OrganizationName", "POCPhone", "PaymentType", "Position", "PrimaryContactId", "RateHourlyOrSalary", "Round" },
                values: new object[,]
                {
                    { new Guid("bf02e668-cdb5-409d-abc9-cc379db08df2"), null, new DateTime(2024, 12, 4, 6, 49, 25, 82, DateTimeKind.Local).AddTicks(2062), false, "InnovateX", "234-567-8901", "Hourly", "Frontend Developer", new Guid("f3751eb7-3533-4911-bfef-c8ea4254e5b8"), 50.0, 1 },
                    { new Guid("edbd9e35-be09-4446-9cb6-8c3b4fcb6fdc"), new Guid("5eb949eb-58cb-48bc-b978-df33e9942c61"), new DateTime(2024, 12, 3, 6, 49, 25, 80, DateTimeKind.Local).AddTicks(6711), true, "TechCorp", "123-456-7890", "Salary", "Software Engineer", null, 120000.0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ContactId",
                table: "Meetings",
                column: "ContactId",
                unique: true,
                filter: "[ContactId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_PrimaryContactId",
                table: "Meetings",
                column: "PrimaryContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
