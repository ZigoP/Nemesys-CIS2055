using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nemesys.Migrations
{
    /// <inheritdoc />
    public partial class modelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigations_Reporters_InvestigatorId",
                table: "Investigations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Reporters_ReporterId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Reporters");

            migrationBuilder.AlterColumn<string>(
                name: "ReporterId",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "InvestigatorId",
                table: "Investigations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportersRanking",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ReportersRanking", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "randomId1", 0, "6382a9e6-6598-4bf0-b86c-d7faa96115da", "Reporter", null, false, false, null, "First", null, null, null, null, false, 1, "c59c931d-2023-48ea-b95d-634d2ecdb903", "Reporter", false, null },
                    { "randomId2", 0, "aa14a395-8dbe-4c13-b825-984e14d84683", "Reporter", null, false, false, null, "Second", null, null, null, null, false, 2, "b2fd4f40-13b0-42c4-a972-d480de141000", "Reporter", false, null }
                });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting", "ReporterId" },
                values: new object[] { new DateTime(2023, 5, 29, 17, 23, 42, 884, DateTimeKind.Utc).AddTicks(7449), new DateTime(2023, 5, 29, 17, 23, 42, 884, DateTimeKind.Utc).AddTicks(7451), "randomId1" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting", "ReporterId" },
                values: new object[] { new DateTime(2023, 5, 28, 17, 23, 42, 884, DateTimeKind.Utc).AddTicks(7453), new DateTime(2023, 5, 27, 17, 23, 42, 884, DateTimeKind.Utc).AddTicks(7457), "randomId2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Investigations_AspNetUsers_InvestigatorId",
                table: "Investigations",
                column: "InvestigatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_ReporterId",
                table: "Reports",
                column: "ReporterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigations_AspNetUsers_InvestigatorId",
                table: "Investigations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_ReporterId",
                table: "Reports");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "randomId1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "randomId2");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReportersRanking",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ReporterId",
                table: "Reports",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "InvestigatorId",
                table: "Investigations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Reporters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportersRanking = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Reporters",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "PhoneNumber", "ReportersRanking", "Surname" },
                values: new object[,]
                {
                    { 10, "Reporter", "adas@gams.sca", "First", "1234567890", 1, "Reporter" },
                    { 11, "Reporter", "adas@gams.sca", "Second", "1234567890", 2, "Reporter" }
                });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting", "ReporterId" },
                values: new object[] { new DateTime(2023, 5, 29, 13, 16, 35, 465, DateTimeKind.Utc).AddTicks(6032), new DateTime(2023, 5, 29, 13, 16, 35, 465, DateTimeKind.Utc).AddTicks(6035), 10 });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting", "ReporterId" },
                values: new object[] { new DateTime(2023, 5, 28, 13, 16, 35, 465, DateTimeKind.Utc).AddTicks(6037), new DateTime(2023, 5, 27, 13, 16, 35, 465, DateTimeKind.Utc).AddTicks(6042), 11 });

            migrationBuilder.AddForeignKey(
                name: "FK_Investigations_Reporters_InvestigatorId",
                table: "Investigations",
                column: "InvestigatorId",
                principalTable: "Reporters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Reporters_ReporterId",
                table: "Reports",
                column: "ReporterId",
                principalTable: "Reporters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
