using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nemesys.Migrations
{
    /// <inheritdoc />
    public partial class stringIdForReporter : Migration
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "adminRoleId", "1", "Admin", "ADMIN" },
                    { "investigatorRoleId", "1", "Invetigator", "INVESTIGATOR" },
                    { "reporterRoleId", "1", "Reporter", "REPORTER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ReportersRanking", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "firstInvestigatorId", 0, "6e6fe156-adec-40c0-9818-580aaaf56ada", "Investigator", null, true, false, null, "First", "DASD@GAMS.SCA", "DASD@GAMS.SCA", "AQAAAAEAACcQAAAAEKGG/pQWkuGmWG+voaOdzBmKVLX3wisjowtMrxgEy7lZVvy4dG5lKt7Qy1DF+0vvqQ==", null, false, 3, "3e835d16-51dc-41bd-a58c-a4a836ac6efe", "Investigator", false, "dasd@gams.sca" },
                    { "firstReporterId", 0, "f292fcf3-ed2f-48a8-a5df-6de7f8c990b1", "Reporter", null, true, false, null, "First", "ADAS@GAMS.SCA", "ADAS@GAMS.SCA", "AQAAAAEAACcQAAAAEOHys+GV7oTS22SXOJrLJcnALYm96dQy+I3r88Z03kqS9/Of4GTQF155jBYCi7UGWw==", null, false, 1, "7547ad37-ff53-4795-ab9e-99a883478e38", "Reporter", false, "adas@gams.sca" },
                    { "secondReporterId", 0, "ce36f31a-ff9a-4ba7-8703-acc2e5ac2de7", "Reporter", null, true, false, null, "Second", "BASD@GAMS.SCA", "BASD@GAMS.SCA", "AQAAAAEAACcQAAAAEPtiNAXWAEarQKWupKort6fFaAKbndKODozvmuyMGmygHGv6nmYLkS2Q4hGil/4u6g==", null, false, 2, "255decfc-f48c-474e-a26a-9e3c90c286b2", "Reporter", false, "basd@gams.sca" }
                });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting", "ReporterId" },
                values: new object[] { new DateTime(2023, 5, 29, 22, 13, 57, 274, DateTimeKind.Utc).AddTicks(3460), new DateTime(2023, 5, 29, 22, 13, 57, 274, DateTimeKind.Utc).AddTicks(3464), "firstReporterId" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting", "ReporterId" },
                values: new object[] { new DateTime(2023, 5, 28, 22, 13, 57, 274, DateTimeKind.Utc).AddTicks(3468), new DateTime(2023, 5, 27, 22, 13, 57, 274, DateTimeKind.Utc).AddTicks(3472), "secondReporterId" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "investigatorRoleId", "firstInvestigatorId" },
                    { "reporterRoleId", "firstReporterId" },
                    { "reporterRoleId", "secondReporterId" }
                });

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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminRoleId");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "investigatorRoleId", "firstInvestigatorId" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "reporterRoleId", "firstReporterId" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "reporterRoleId", "secondReporterId" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "investigatorRoleId");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "reporterRoleId");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstInvestigatorId");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstReporterId");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "secondReporterId");

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
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ReportersRanking = table.Column<int>(type: "int", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    { 10, 0, "00f53e0e-6935-4e9e-829a-81593a611e8a", "Reporter", "adas@gams.sca", true, false, null, "First", "ADAS@GAMS.SCA", "ADAS@GAMS.SCA", "AQAAAAEAACcQAAAAEFhiu9yxsLFjOxLif20Jd+PDP+TlJ9YpI4eyiH5IkTUV31nituN/Jt8IT4PSsJ1OCA==", "1234567890", false, 1, null, "Reporter", false, "adas@gams.sca" },
                    { 11, 0, "7793656f-a52f-4c25-9d70-5f2f9b545f7d", "Reporter", "basd@gams.sca", true, false, null, "Second", "BASD@GAMS.SCA", "BASD@GAMS.SCA", "AQAAAAEAACcQAAAAEIDB5INfSfCczF9leV+C87nBRrV1HcjYx7vbtu+ZlCMxureS6IUkiI9QL7r1zZnjkA==", "1234567890", false, 2, null, "Reporter", false, "basd@gams.sca" },
                    { 12, 0, "3e565980-2c7f-42b9-b5ca-4165b35c125d", "Investigator", "dasd@gams.sca", true, false, null, "First", "DASD@GAMS.SCA", "DASD@GAMS.SCA", "AQAAAAEAACcQAAAAEByZLXNpLnQbOt3th9AoAhndQGmYJc3VB8en1jmyovacxkdaQ0kviCMKlxzKRAwhOQ==", "1234567890", false, 3, null, "Investigator", false, "dasd@gams.sca" }
                });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting", "ReporterId" },
                values: new object[] { new DateTime(2023, 5, 29, 21, 39, 28, 618, DateTimeKind.Utc).AddTicks(7911), new DateTime(2023, 5, 29, 21, 39, 28, 618, DateTimeKind.Utc).AddTicks(7913), 10 });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting", "ReporterId" },
                values: new object[] { new DateTime(2023, 5, 28, 21, 39, 28, 618, DateTimeKind.Utc).AddTicks(7920), new DateTime(2023, 5, 27, 21, 39, 28, 618, DateTimeKind.Utc).AddTicks(7926), 11 });

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
