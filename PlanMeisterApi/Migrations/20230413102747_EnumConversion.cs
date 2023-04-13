using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanMeisterApi.Migrations
{
    /// <inheritdoc />
    public partial class EnumConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestType",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1,
                column: "RequestType",
                value: "Vakantie");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2,
                column: "RequestType",
                value: "Vakantie");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 3,
                column: "RequestType",
                value: "Vakantie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RequestType",
                table: "Requests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 1,
                column: "RequestType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 2,
                column: "RequestType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "RequestId",
                keyValue: 3,
                column: "RequestType",
                value: 0);
        }
    }
}
