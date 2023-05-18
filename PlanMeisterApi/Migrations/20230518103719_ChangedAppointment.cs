using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanMeisterApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Appointments");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "Appointments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "Appointments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 4, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 1, 7, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 1, 15, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                columns: new[] { "EndDateTime", "StartDateTime" },
                values: new object[] { new DateTime(2023, 4, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 1, 23, 45, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "Appointments");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Appointments",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 45, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 45, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 23, 45, 0, 0) });
        }
    }
}
