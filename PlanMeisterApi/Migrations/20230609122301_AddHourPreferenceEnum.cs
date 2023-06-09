using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanMeisterApi.Migrations
{
    /// <inheritdoc />
    public partial class AddHourPreferenceEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HourPreferenceStatus",
                table: "HourPreferences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "HourPreferences",
                keyColumn: "HourPreferenceId",
                keyValue: 1,
                column: "HourPreferenceStatus",
                value: "Processing");

            migrationBuilder.UpdateData(
                table: "HourPreferences",
                keyColumn: "HourPreferenceId",
                keyValue: 2,
                column: "HourPreferenceStatus",
                value: "Processing");

            migrationBuilder.UpdateData(
                table: "HourPreferences",
                keyColumn: "HourPreferenceId",
                keyValue: 3,
                column: "HourPreferenceStatus",
                value: "Processing");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourPreferenceStatus",
                table: "HourPreferences");
        }
    }
}
