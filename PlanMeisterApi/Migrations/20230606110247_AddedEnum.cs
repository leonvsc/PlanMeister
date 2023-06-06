using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanMeisterApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DateTill",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TimeFrom",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "TimeTill",
                table: "Requests",
                newName: "RequestStatus");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeFrom",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeTill",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "Type",
                value: "MorningShift");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                column: "Type",
                value: "EveningShift");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                column: "Type",
                value: "NightShift");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1,
                columns: new[] { "DateTimeFrom", "DateTimeTill", "RequestStatus", "RequestType" },
                values: new object[] { new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "Vacation" });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2,
                columns: new[] { "DateTimeFrom", "DateTimeTill", "RequestStatus", "RequestType" },
                values: new object[] { new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "Vacation" });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 3,
                columns: new[] { "DateTimeFrom", "DateTimeTill", "RequestStatus", "RequestType" },
                values: new object[] { new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Processing", "Vacation" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeFrom",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DateTimeTill",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "RequestStatus",
                table: "Requests",
                newName: "TimeTill");

            migrationBuilder.AddColumn<string>(
                name: "DateFrom",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateTill",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeFrom",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "Type",
                value: "Ochtenddienst");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                column: "Type",
                value: "Avonddienst");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                column: "Type",
                value: "Nachtdienst");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTill", "RequestType", "TimeFrom", "TimeTill" },
                values: new object[] { "01-04-2023", "10-04-2023", "Vakantie", "00:00", "23:59" });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTill", "RequestType", "TimeFrom", "TimeTill" },
                values: new object[] { "01-04-2023", "10-04-2023", "Vakantie", "00:00", "23:59" });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTill", "RequestType", "TimeFrom", "TimeTill" },
                values: new object[] { "01-04-2023", "10-04-2023", "Vakantie", "00:00", "23:59" });
        }
    }
}
