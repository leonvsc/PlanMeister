using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanMeisterApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSeeddata25052023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(23, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(23, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DaySchedules",
                keyColumn: "DayScheduleId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(23, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
