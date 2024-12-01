﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
