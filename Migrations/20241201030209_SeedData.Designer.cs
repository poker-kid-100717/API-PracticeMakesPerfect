﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241201030209_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Domain.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsInterviewSchedule")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3456881f-9bb2-45e1-967e-0ea84e39bbf6"),
                            Email = "alice.johnson@techcorp.com",
                            IsInterviewSchedule = true,
                            Name = "Alice Johnson",
                            OrganizationName = "TechCorp",
                            Phone = "123-456-7890"
                        },
                        new
                        {
                            Id = new Guid("c380f320-ef9e-464e-ab66-ac06f45b9657"),
                            Email = "bob.smith@innovatex.com",
                            IsInterviewSchedule = false,
                            Name = "Bob Smith",
                            OrganizationName = "InnovateX",
                            Phone = "234-567-8901"
                        });
                });

            modelBuilder.Entity("API.Models.Domain.Meeting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("InterviewDateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsRemote")
                        .HasColumnType("bit");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("POCPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PrimaryContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("RateHourlyOrSalary")
                        .HasColumnType("float");

                    b.Property<int?>("Round")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContactId")
                        .IsUnique()
                        .HasFilter("[ContactId] IS NOT NULL");

                    b.HasIndex("PrimaryContactId");

                    b.ToTable("Meetings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("88f6ce53-73d2-45ce-bbeb-e92edaed3199"),
                            ContactId = new Guid("3456881f-9bb2-45e1-967e-0ea84e39bbf6"),
                            InterviewDateAndTime = new DateTime(2024, 12, 2, 20, 2, 9, 70, DateTimeKind.Local).AddTicks(6846),
                            IsRemote = true,
                            OrganizationName = "TechCorp",
                            POCPhone = "123-456-7890",
                            PaymentType = "Salary",
                            Position = "Software Engineer",
                            RateHourlyOrSalary = 120000.0,
                            Round = 1
                        },
                        new
                        {
                            Id = new Guid("e0fabd37-2843-4bd9-876d-33e263faaf02"),
                            InterviewDateAndTime = new DateTime(2024, 12, 3, 20, 2, 9, 72, DateTimeKind.Local).AddTicks(8150),
                            IsRemote = false,
                            OrganizationName = "InnovateX",
                            POCPhone = "234-567-8901",
                            PaymentType = "Hourly",
                            Position = "Frontend Developer",
                            PrimaryContactId = new Guid("c380f320-ef9e-464e-ab66-ac06f45b9657"),
                            RateHourlyOrSalary = 50.0,
                            Round = 1
                        });
                });

            modelBuilder.Entity("API.Models.Domain.Meeting", b =>
                {
                    b.HasOne("API.Models.Domain.Contact", "Contact")
                        .WithOne("Meeting")
                        .HasForeignKey("API.Models.Domain.Meeting", "ContactId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("API.Models.Domain.Contact", "PrimaryContact")
                        .WithMany("Meetings")
                        .HasForeignKey("PrimaryContactId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Contact");

                    b.Navigation("PrimaryContact");
                });

            modelBuilder.Entity("API.Models.Domain.Contact", b =>
                {
                    b.Navigation("Meeting");

                    b.Navigation("Meetings");
                });
#pragma warning restore 612, 618
        }
    }
}