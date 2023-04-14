using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanMeisterApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 2,
                column: "WeekScheduleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 3,
                column: "WeekScheduleId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 2,
                column: "WeekScheduleId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 3,
                column: "WeekScheduleId",
                value: 3);
        }
    }
}
