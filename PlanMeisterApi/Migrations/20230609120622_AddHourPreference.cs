using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanMeisterApi.Migrations
{
    /// <inheritdoc />
    public partial class AddHourPreference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HourPreferences",
                columns: table => new
                {
                    HourPreferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    AmountOfHours = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourPreferences", x => x.HourPreferenceId);
                });

            migrationBuilder.InsertData(
                table: "HourPreferences",
                columns: new[] { "HourPreferenceId", "AmountOfHours", "EmployeeId", "WeekNumber" },
                values: new object[,]
                {
                    { 1, 32, 1, 23 },
                    { 2, 40, 2, 23 },
                    { 3, 24, 3, 23 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourPreferences");
        }
    }
}
