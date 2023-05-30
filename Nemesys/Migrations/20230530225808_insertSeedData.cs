using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    /// <inheritdoc />
    public partial class insertSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ReportersRanking", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "firstInvestigatorId", 0, "6e6fe156-adec-40c0-9818-580aaaf56ada", "Investigator", "michael@gmail.com", true, false, null, "Michael", "MICHAEL@GMAIL.COM", "MICHAEL@GMAIL.COM", "AQAAAAEAACcQAAAAEKGG/pQWkuGmWG+voaOdzBmKVLX3wisjowtMrxgEy7lZVvy4dG5lKt7Qy1DF+0vvqQ==", "+356 91286821", false, 3, "3e835d16-51dc-41bd-a58c-a4a836ac6efe", "Investigator", false, "michael@gmail.com" },
                    { "firstReporterId", 0, "f292fcf3-ed2f-48a8-a5df-6de7f8c990b1", "Reporter", "patrikzigo@gmail.com", true, false, null, "Patrik", "PATRIKZIGO@GMAIL.COM", "PATRIKZIGO@GMAIL.COM", "AQAAAAEAACcQAAAAEOHys+GV7oTS22SXOJrLJcnALYm96dQy+I3r88Z03kqS9/Of4GTQF155jBYCi7UGWw==", "+356 91821310", false, 1, "7547ad37-ff53-4795-ab9e-99a883478e38", "Reporter", false, "patrikzigo@gmail.com" },
                    { "secondReporterId", 0, "ce36f31a-ff9a-4ba7-8703-acc2e5ac2de7", "Reporter", "beyalibulut@gmail.com", true, false, null, "Ali", "BEYALIBULUT@GMAIL.COM", "BEYALIBULUT@GMAIL.COM", "AQAAAAEAACcQAAAAEPtiNAXWAEarQKWupKort6fFaAKbndKODozvmuyMGmygHGv6nmYLkS2Q4hGil/4u6g==", "+356 99780821", false, 2, "255decfc-f48c-474e-a26a-9e3c90c286b2", "Reporter", false, "beyalibulut@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Name", "DateOfReport", "DateOfSpotting", "Description", "ImageUrl", "InvestigationId", "Location", "ReporterId", "Status", "TypeOfHazard", "UpVotes" },
                values: new object[,]
                {
                    { 1, "Pool is broken", new DateTime(2023, 5, 28, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7726), new DateTime(2023, 5, 28, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7728), "Pool in the Campus Hub is Broken. Don't ask how. Its just broken", "https://media.istockphoto.com/id/521812033/photo/lawn-chairs-overlooking-backyard-and-swimming-pool.jpg?s=1024x1024&w=is&k=20&c=IZd3LZBnIwn4PB8zuZxzOjB95jpPqH5kcxH9V1cygBc=", null, "Campus Hub Piazza", "firstReporterId", 0, 4, 5 },
                    { 2, "Fallen tree in the middle of campus", new DateTime(2023, 5, 27, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7731), new DateTime(2023, 5, 26, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7735), "One of the tree's in Quads fell down", "https://images.freeimages.com/images/large-previews/3c2/victim-of-a-storm-2-1638820.jpg", null, "Campus Quads", "secondReporterId", 0, 1, 7 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstInvestigatorId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a802fa00-8edc-49ab-b12f-c5b68cf674ff", "AQAAAAEAACcQAAAAEI8fgo/2563yRqE1PgI6T2LksPh6l2jrbFFnh+YV1dF4cVej4LiG/5fajAc0R5bxeg==", "8bda27cc-fe05-45db-8853-19fc32f81ff8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstReporterId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1ec27f5-dc04-48b3-903c-e7af8b7d9a61", "AQAAAAEAACcQAAAAEEiW6ZHXKvv2e2wiSy/FEwuB0QZfIEieJxypbtilEJFnByRvHhay2FlYg3dnR5j51g==", "36314ad6-3b62-4a4a-95be-e49e0a9b95cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "secondReporterId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c4d3421-0661-4383-9fad-69003006df8c", "AQAAAAEAACcQAAAAEPIiREavYLZC5915xMwzBGreJ3IeXWzELDF1zEPZIyclP5oxZ6QmCgW6KIRRYZV2SA==", "99e7a6c9-bec5-4d16-b826-f54d61736159" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 30, 22, 58, 7, 800, DateTimeKind.Utc).AddTicks(4433), new DateTime(2023, 5, 30, 22, 58, 7, 800, DateTimeKind.Utc).AddTicks(4436) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 29, 22, 58, 7, 800, DateTimeKind.Utc).AddTicks(4441), new DateTime(2023, 5, 28, 22, 58, 7, 800, DateTimeKind.Utc).AddTicks(4446) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstInvestigatorId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "076b1ab5-b058-4ebb-aaa4-b186fcc46b6d", "AQAAAAEAACcQAAAAEIAzCMdSQ1tZeNAzAgtzlrGwH0+lZXKgiZENEoZ2sU3Ni7l6WRsql6h3BFa9fEZpYw==", "1a159dff-90da-48d5-83dd-ef5f5d895ea4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstReporterId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c13a5033-0ee4-4cf2-bbaa-13f64b52bdcb", "AQAAAAEAACcQAAAAEFHBEbx1xu+O4VsZRkZD/SHzuhNuN9w/o8TgIfqA4pH6ESfB16vFK3+xDKV4kYHCQA==", "5a398484-f6d8-4b19-8ce3-85d49b01f7b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "secondReporterId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ba4f084-f602-45dc-9bfa-8c2795a12a98", "AQAAAAEAACcQAAAAEFRojjx80sbBq1m9fd/COl8GZXl1/DqGQaFyCF+OU6egmKzGeN33iGIj72qo0eE21Q==", "b3e5ce2d-058e-4f60-84f7-f1540f93fc7a" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 30, 22, 41, 1, 233, DateTimeKind.Utc).AddTicks(2351), new DateTime(2023, 5, 30, 22, 41, 1, 233, DateTimeKind.Utc).AddTicks(2354) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 29, 22, 41, 1, 233, DateTimeKind.Utc).AddTicks(2360), new DateTime(2023, 5, 28, 22, 41, 1, 233, DateTimeKind.Utc).AddTicks(2366) });
        }
    }
}
