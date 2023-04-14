using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanMeisterApi.Migrations
{
    /// <inheritdoc />
    public partial class RenamedTablesAndRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "WeekSchedules",
                columns: table => new
                {
                    WeekScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekSchedules", x => x.WeekScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeTill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaySchedules",
                columns: table => new
                {
                    DayScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    WeekScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaySchedules", x => x.DayScheduleId);
                    table.ForeignKey(
                        name: "FK_DaySchedules_WeekSchedules_WeekScheduleId",
                        column: x => x.WeekScheduleId,
                        principalTable: "WeekSchedules",
                        principalColumn: "WeekScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Billable = table.Column<bool>(type: "bit", nullable: false),
                    DayScheduleId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_DaySchedules_DayScheduleId",
                        column: x => x.DayScheduleId,
                        principalTable: "DaySchedules",
                        principalColumn: "DayScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Name" },
                values: new object[,]
                {
                    { 1, "Hans" },
                    { 2, "Klaas" },
                    { 3, "Piet" }
                });

            migrationBuilder.InsertData(
                table: "WeekSchedules",
                columns: new[] { "WeekScheduleId", "WeekNumber" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "DaySchedules",
                columns: new[] { "DayScheduleId", "DayOfWeek", "WeekScheduleId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "DateFrom", "DateTill", "EmployeeId", "RequestType", "TimeFrom", "TimeTill" },
                values: new object[,]
                {
                    { 1, "01-04-2023", "10-04-2023", 1, "Vakantie", "00:00", "23:59" },
                    { 2, "01-04-2023", "10-04-2023", 2, "Vakantie", "00:00", "23:59" },
                    { 3, "01-04-2023", "10-04-2023", 3, "Vakantie", "00:00", "23:59" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "Billable", "Date", "DayScheduleId", "Description", "EmployeeId", "Time", "Title", "Type" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ziggo Playout Ochtenddienst", 1, new TimeSpan(0, 7, 45, 0, 0), "Ziggo Playout", 0 },
                    { 2, true, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ziggo Playout Avonddienst", 2, new TimeSpan(0, 15, 45, 0, 0), "Ziggo Playout", 1 },
                    { 3, true, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ziggo Playout Nachtdienst", 3, new TimeSpan(0, 23, 45, 0, 0), "Ziggo Playout", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DayScheduleId",
                table: "Appointments",
                column: "DayScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_EmployeeId",
                table: "Appointments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DaySchedules_WeekScheduleId",
                table: "DaySchedules",
                column: "WeekScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_EmployeeId",
                table: "Requests",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "DaySchedules");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "WeekSchedules");
        }
    }
}
