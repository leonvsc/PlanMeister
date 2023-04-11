using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanMeisterApi.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Task = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Billable = table.Column<bool>(type: "bit", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayId);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestType = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeTill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "Billable", "Date", "DayId", "Description", "EmployeeId", "Name", "Task", "Time", "Type" },
                values: new object[,]
                {
                    { 1, true, "01-04-2023", 0, "Ziggo Playout Ochtenddienst", 0, "Ziggo Playout", "Ziggo Playout", "07:45", "Ziggo Playout" },
                    { 2, true, "01-04-2023", 0, "Ziggo Playout Avonddienst", 0, "Ziggo Playout", "Ziggo Playout", "15:45", "Ziggo Playout" },
                    { 3, true, "01-04-2023", 0, "Ziggo Playout Nachtdienst", 0, "Ziggo Playout", "Ziggo Playout", "23:45", "Ziggo Playout" }
                });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "DayId", "AppointmentId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Maandag" },
                    { 2, 2, "Dinsdag" },
                    { 3, 3, "Woensdag" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "DateFrom", "DateTill", "EmployeeId", "RequestType", "TimeFrom", "TimeTill" },
                values: new object[,]
                {
                    { 1, "01-04-2023", "10-04-2023", 1, 0, "00:00", "23:59" },
                    { 2, "01-04-2023", "10-04-2023", 2, 0, "00:00", "23:59" },
                    { 3, "01-04-2023", "10-04-2023", 3, 0, "00:00", "23:59" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "DayId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
