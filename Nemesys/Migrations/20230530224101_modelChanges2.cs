using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    /// <inheritdoc />
    public partial class modelChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Reporters",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "PhoneNumber", "ReportersRanking", "Surname" },
                values: new object[,]
                {
                    { "firstReporterId", "Reporter", "patrikzigo@gmail.com", "Patrik", "+356 91821310", 1, "Reporter" },
                    { "secondReporterId", "Reporter", "beyalibulut@gmail.com", "Ali", "+356 99780821", 2, "Reporter" }
                });
            migrationBuilder.InsertData(
                table: "Investigators",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "PhoneNumber", "ReportersRanking", "Surname" },
                values: new object[,]
                {
                    { "firstInvestigatorId", "Investigator", "michael@gmail.com", "Michael", "+356 91286821", 3, "Investigator" },
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Name","DateOfReport", "DateOfSpotting", "Description", "ImageUrl", "InvestigationId", "Location", "ReporterId", "Status", "TypeOfHazard", "UpVotes" },
                values: new object[,]
                {
                    { 1, "Pool is broken", new DateTime(2023, 5, 28, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7726), new DateTime(2023, 5, 28, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7728), "Pool in the Campus Hub is Broken. Don't ask how. Its just broken", "https://media.istockphoto.com/id/521812033/photo/lawn-chairs-overlooking-backyard-and-swimming-pool.jpg?s=1024x1024&w=is&k=20&c=IZd3LZBnIwn4PB8zuZxzOjB95jpPqH5kcxH9V1cygBc=", null, "Campus Hub Piazza", "firstReporterId", 0, 4, 5 },
                    { 2, "Fallen tree in the middle of campus", new DateTime(2023, 5, 27, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7731), new DateTime(2023, 5, 26, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7735), "One of the tree's in Quads fell down", "https://images.freeimages.com/images/large-previews/3c2/victim-of-a-storm-2-1638820.jpg", null, "Campus Quads", "secondReporterId", 0, 1, 7 }
                });

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Reports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Investigations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Investigations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstInvestigatorId",
                columns: new[] { "ConcurrencyStamp", "Email", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "076b1ab5-b058-4ebb-aaa4-b186fcc46b6d", "michael@gmail.com", "Michael", "MICHAEL@GMAIL.COM", "MICHAEL@GMAIL.COM", "AQAAAAEAACcQAAAAEIAzCMdSQ1tZeNAzAgtzlrGwH0+lZXKgiZENEoZ2sU3Ni7l6WRsql6h3BFa9fEZpYw==", "+356 91286821", "1a159dff-90da-48d5-83dd-ef5f5d895ea4", "michael@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstReporterId",
                columns: new[] { "ConcurrencyStamp", "Email", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "c13a5033-0ee4-4cf2-bbaa-13f64b52bdcb", "patrikzigo@gmail.com", "Patrik", "PATRIKZIGO@GMAIL.COM", "PATRIKZIGO@GMAIL.COM", "AQAAAAEAACcQAAAAEFHBEbx1xu+O4VsZRkZD/SHzuhNuN9w/o8TgIfqA4pH6ESfB16vFK3+xDKV4kYHCQA==", "+356 91821310", "5a398484-f6d8-4b19-8ce3-85d49b01f7b2", "patrikzigo@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "secondReporterId",
                columns: new[] { "ConcurrencyStamp", "Email", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "1ba4f084-f602-45dc-9bfa-8c2795a12a98", "beyalibulut@gmail.com", "Ali", "BEYALIBULUT@GMAIL.COM", "BEYALIBULUT@GMAIL.COM", "AQAAAAEAACcQAAAAEFRojjx80sbBq1m9fd/COl8GZXl1/DqGQaFyCF+OU6egmKzGeN33iGIj72qo0eE21Q==", "+356 99780821", "b3e5ce2d-058e-4f60-84f7-f1540f93fc7a", "beyalibulut@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting", "Description", "ImageUrl", "LastUpdateDate", "Location", "Name" },
                values: new object[] { new DateTime(2023, 5, 30, 22, 41, 1, 233, DateTimeKind.Utc).AddTicks(2351), new DateTime(2023, 5, 30, 22, 41, 1, 233, DateTimeKind.Utc).AddTicks(2354), "Pool in the Campus Hub is Broken. Don't ask how. Its just broken", "https://media.istockphoto.com/id/521812033/photo/lawn-chairs-overlooking-backyard-and-swimming-pool.jpg?s=1024x1024&w=is&k=20&c=IZd3LZBnIwn4PB8zuZxzOjB95jpPqH5kcxH9V1cygBc=", null, "Campus Hub Piazza", "Pool is broken" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting", "Description", "ImageUrl", "LastUpdateDate", "Location", "Name", "TypeOfHazard" },
                values: new object[] { new DateTime(2023, 5, 29, 22, 41, 1, 233, DateTimeKind.Utc).AddTicks(2360), new DateTime(2023, 5, 28, 22, 41, 1, 233, DateTimeKind.Utc).AddTicks(2366), "One of the tree's in Quads fell down", "https://images.freeimages.com/images/large-previews/3c2/victim-of-a-storm-2-1638820.jpg", null, "Campus Quads", "Fallen tree in the middle of campus", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Investigations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Investigations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstInvestigatorId",
                columns: new[] { "ConcurrencyStamp", "Email", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "6826e668-b57f-43b8-aeee-0d75501c4323", "dasd@gams.sca", "First", "DASD@GAMS.SCA", "DASD@GAMS.SCA", "AQAAAAEAACcQAAAAEGo/uKbusQlja+UnGFWZNuWLauAj74f7wlYm8bqZpq4YcI4BEFA7EZpcVdJPUPwadA==", "1234567890", "6f14ef54-f8b8-4611-b204-9d63f4107979", "dasd@gams.sca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstReporterId",
                columns: new[] { "ConcurrencyStamp", "Email", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "6ffe1548-bc91-4f8e-b00e-33370790f688", "adas@gams.sca", "First", "ADAS@GAMS.SCA", "ADAS@GAMS.SCA", "AQAAAAEAACcQAAAAEMVuoKKlhdwA3aGbohqMp2vKNxwgbdH4MX37S8CI1GxHx7h6ztVvtObpwJN9KlHkXg==", "1234567890", "002d0d10-8213-4c1c-ab82-5b9e0c6d3d29", "adas@gams.sca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "secondReporterId",
                columns: new[] { "ConcurrencyStamp", "Email", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "53223edc-8e81-4245-9ba4-71c9602a4e40", "basd@gams.sca", "Second", "BASD@GAMS.SCA", "BASD@GAMS.SCA", "AQAAAAEAACcQAAAAEDB1X69+MyrARvOrpf0qOQqBQNIRdkKLdp71o4B3/9vWkKRFgqxz0FpFiaU96Xe1kA==", "1234567890", "55039949-ae76-4427-ad53-27bf00fb0510", "basd@gams.sca" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting", "Description", "ImageUrl", "Location" },
                values: new object[] { new DateTime(2023, 5, 29, 22, 15, 49, 539, DateTimeKind.Utc).AddTicks(6835), new DateTime(2023, 5, 29, 22, 15, 49, 539, DateTimeKind.Utc).AddTicks(6838), "asdasd", "", "asdasd" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting", "Description", "ImageUrl", "Location", "TypeOfHazard" },
                values: new object[] { new DateTime(2023, 5, 28, 22, 15, 49, 539, DateTimeKind.Utc).AddTicks(6849), new DateTime(2023, 5, 27, 22, 15, 49, 539, DateTimeKind.Utc).AddTicks(6854), "asdvsdvvsdvsasd", "", "asadsdfdvdfvdasd", 2 });
        }
    }
}
