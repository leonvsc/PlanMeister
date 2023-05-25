﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanMeisterApi.Models;

#nullable disable

namespace PlanMeisterApi.Migrations
{
    [DbContext(typeof(PlanMeisterDbContext))]
    partial class PlanMeisterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlanMeisterApi.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<bool>("Billable")
                        .HasColumnType("bit");

                    b.Property<int>("DayScheduleId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppointmentId");

                    b.HasIndex("DayScheduleId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            AppointmentId = 1,
                            Billable = true,
                            DayScheduleId = 1,
                            Description = "Ziggo Playout Ochtenddienst",
                            EmployeeId = 1,
                            EndDateTime = new DateTime(2023, 4, 1, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDateTime = new DateTime(2023, 4, 1, 7, 45, 0, 0, DateTimeKind.Unspecified),
                            Title = "Ziggo Playout",
                            Type = "Ochtenddienst"
                        },
                        new
                        {
                            AppointmentId = 2,
                            Billable = true,
                            DayScheduleId = 2,
                            Description = "Ziggo Playout Avonddienst",
                            EmployeeId = 2,
                            EndDateTime = new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDateTime = new DateTime(2023, 4, 1, 15, 45, 0, 0, DateTimeKind.Unspecified),
                            Title = "Ziggo Playout",
                            Type = "Avonddienst"
                        },
                        new
                        {
                            AppointmentId = 3,
                            Billable = true,
                            DayScheduleId = 3,
                            Description = "Ziggo Playout Nachtdienst",
                            EmployeeId = 3,
                            EndDateTime = new DateTime(2023, 4, 2, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDateTime = new DateTime(2023, 4, 1, 23, 45, 0, 0, DateTimeKind.Unspecified),
                            Title = "Ziggo Playout",
                            Type = "Nachtdienst"
                        });
                });

            modelBuilder.Entity("PlanMeisterApi.Models.DaySchedule", b =>
                {
                    b.Property<int>("DayScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DayScheduleId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DayOfWeek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeekScheduleId")
                        .HasColumnType("int");

                    b.HasKey("DayScheduleId");

                    b.HasIndex("WeekScheduleId");

                    b.ToTable("DaySchedules");

                    b.HasData(
                        new
                        {
                            DayScheduleId = 1,
                            Date = new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DayOfWeek = "Monday",
                            WeekScheduleId = 1
                        },
                        new
                        {
                            DayScheduleId = 2,
                            Date = new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DayOfWeek = "Tuesday",
                            WeekScheduleId = 1
                        },
                        new
                        {
                            DayScheduleId = 3,
                            Date = new DateTime(2023, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DayOfWeek = "Wednesday",
                            WeekScheduleId = 1
                        });
                });

            modelBuilder.Entity("PlanMeisterApi.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Name = "Hans"
                        },
                        new
                        {
                            EmployeeId = 2,
                            Name = "Klaas"
                        },
                        new
                        {
                            EmployeeId = 3,
                            Name = "Piet"
                        });
                });

            modelBuilder.Entity("PlanMeisterApi.Models.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<string>("DateFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateTill")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("RequestType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeTill")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Requests");

                    b.HasData(
                        new
                        {
                            RequestId = 1,
                            DateFrom = "01-04-2023",
                            DateTill = "10-04-2023",
                            EmployeeId = 1,
                            RequestType = "Vakantie",
                            TimeFrom = "00:00",
                            TimeTill = "23:59"
                        },
                        new
                        {
                            RequestId = 2,
                            DateFrom = "01-04-2023",
                            DateTill = "10-04-2023",
                            EmployeeId = 2,
                            RequestType = "Vakantie",
                            TimeFrom = "00:00",
                            TimeTill = "23:59"
                        },
                        new
                        {
                            RequestId = 3,
                            DateFrom = "01-04-2023",
                            DateTill = "10-04-2023",
                            EmployeeId = 3,
                            RequestType = "Vakantie",
                            TimeFrom = "00:00",
                            TimeTill = "23:59"
                        });
                });

            modelBuilder.Entity("PlanMeisterApi.Models.WeekSchedule", b =>
                {
                    b.Property<int>("WeekScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeekScheduleId"));

                    b.Property<int>("WeekNumber")
                        .HasColumnType("int");

                    b.HasKey("WeekScheduleId");

                    b.ToTable("WeekSchedules");

                    b.HasData(
                        new
                        {
                            WeekScheduleId = 1,
                            WeekNumber = 1
                        },
                        new
                        {
                            WeekScheduleId = 2,
                            WeekNumber = 2
                        },
                        new
                        {
                            WeekScheduleId = 3,
                            WeekNumber = 3
                        });
                });

            modelBuilder.Entity("PlanMeisterApi.Models.Appointment", b =>
                {
                    b.HasOne("PlanMeisterApi.Models.DaySchedule", "DaySchedule")
                        .WithMany("Appointments")
                        .HasForeignKey("DayScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlanMeisterApi.Models.Employee", "Employee")
                        .WithMany("Appointments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DaySchedule");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PlanMeisterApi.Models.DaySchedule", b =>
                {
                    b.HasOne("PlanMeisterApi.Models.WeekSchedule", "WeekSchedule")
                        .WithMany("DaySchedules")
                        .HasForeignKey("WeekScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WeekSchedule");
                });

            modelBuilder.Entity("PlanMeisterApi.Models.Request", b =>
                {
                    b.HasOne("PlanMeisterApi.Models.Employee", "Employee")
                        .WithMany("Requests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PlanMeisterApi.Models.DaySchedule", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("PlanMeisterApi.Models.Employee", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("PlanMeisterApi.Models.WeekSchedule", b =>
                {
                    b.Navigation("DaySchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
