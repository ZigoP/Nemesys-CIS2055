using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nemesys.Migrations
{
    /// <inheritdoc />
    public partial class dbContextChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportersRanking = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Reporters",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ReportersRanking", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 10, 0, "40eefd76-04b0-4872-ae5e-8d2008e79423", "Reporter", "adas@gams.sca", true, false, null, "First", "ADAS@GAMS.SCA", "ADAS@GAMS.SCA", "AQAAAAEAACcQAAAAEN8B/rYRjgkJjUua4HkCjzbSkyTDa+WjwGUsdo8IqmnK1AvmofUVnBm4XsZ977IofA==", "1234567890", false, 1, null, "Reporter", false, "adas@gams.sca" },
                    { 11, 0, "53895128-f998-4b82-bc4a-3a3582c37d4e", "Reporter", "basd@gams.sca", true, false, null, "Second", "BASD@GAMS.SCA", "BASD@GAMS.SCA", "AQAAAAEAACcQAAAAEDXB30gljjb1GBnWIvVXb4zfD+EdkSa6hhCKwgWLETJa26xTJxd/hJIlQDKD/fg2Aw==", "1234567890", false, 2, null, "Reporter", false, "basd@gams.sca" }
                });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting", "ReporterId" },
                values: new object[] { new DateTime(2023, 5, 29, 20, 12, 49, 404, DateTimeKind.Utc).AddTicks(8173), new DateTime(2023, 5, 29, 20, 12, 49, 404, DateTimeKind.Utc).AddTicks(8178), 10 });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting", "ReporterId" },
                values: new object[] { new DateTime(2023, 5, 28, 20, 12, 49, 404, DateTimeKind.Utc).AddTicks(8180), new DateTime(2023, 5, 27, 20, 12, 49, 404, DateTimeKind.Utc).AddTicks(8185), 11 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "DateOfReport", "DateOfSpotting", "Description", "ImageUrl", "InvestigationId", "Location", "ReporterId", "Status", "TypeOfHazard", "UpVotes" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 28, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7726), new DateTime(2023, 5, 28, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7728), "asdasd", "", null, "asdasd", 10, 0, 4, 5 },
                    { 2, new DateTime(2023, 5, 27, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7731), new DateTime(2023, 5, 26, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7735), "asdvsdvvsdvsasd", "", null, "asadsdfdvdfvdasd", 11, 0, 2, 7 }
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
    }
}
