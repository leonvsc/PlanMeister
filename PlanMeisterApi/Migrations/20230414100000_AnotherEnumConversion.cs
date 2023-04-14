using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanMeisterApi.Migrations
{
    /// <inheritdoc />
    public partial class AnotherEnumConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DayOfWeek",
                table: "DaySchedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 1,
                column: "DayOfWeek",
                value: "Monday");

            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 2,
                column: "DayOfWeek",
                value: "Tuesday");

            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 3,
                column: "DayOfWeek",
                value: "Wednesday");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DayOfWeek",
                table: "DaySchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 3,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 1,
                column: "DayOfWeek",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 2,
                column: "DayOfWeek",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 3,
                column: "DayOfWeek",
                value: 3);
        }
    }
}
