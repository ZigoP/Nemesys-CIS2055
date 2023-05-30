using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    /// <inheritdoc />
    public partial class dbContextChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "DateOfReport", "DateOfSpotting", "Description", "ImageUrl", "InvestigationId", "Location", "ReporterId", "Status", "TypeOfHazard", "UpVotes" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 28, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7726), new DateTime(2023, 5, 28, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7728), "asdasd", "", null, "asdasd", 10, 0, 4, 5 },
                    { 2, new DateTime(2023, 5, 27, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7731), new DateTime(2023, 5, 26, 16, 49, 54, 464, DateTimeKind.Utc).AddTicks(7735), "asdvsdvvsdvsasd", "", null, "asadsdfdvdfvdasd", 11, 0, 2, 7 }
                });

            migrationBuilder.UpdateData(
                table: "Reporters",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ef22e2e7-e0e1-4b8f-9d0d-da2ad3e15d7c", "AQAAAAEAACcQAAAAEGZOlsMS5JOvTi1M9dv9lQsSWx/shAQxvi2nGf3d87b/QP81nnihmt5fvvzC8+yvug==" });

            migrationBuilder.UpdateData(
                table: "Reporters",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "feb02efc-c513-42ec-a5e1-fa62136eef7d", "AQAAAAEAACcQAAAAEN8q8t+xIJEA+jbDIa6RgNbyYt+Rhf2j00xZQ49SjugxXDarDgIQxAqxQlJyldAJ6A==" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 29, 20, 20, 28, 723, DateTimeKind.Utc).AddTicks(9752), new DateTime(2023, 5, 29, 20, 20, 28, 723, DateTimeKind.Utc).AddTicks(9755) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 28, 20, 20, 28, 723, DateTimeKind.Utc).AddTicks(9757), new DateTime(2023, 5, 27, 20, 20, 28, 723, DateTimeKind.Utc).AddTicks(9762) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reporters",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "40eefd76-04b0-4872-ae5e-8d2008e79423", "AQAAAAEAACcQAAAAEN8B/rYRjgkJjUua4HkCjzbSkyTDa+WjwGUsdo8IqmnK1AvmofUVnBm4XsZ977IofA==" });

            migrationBuilder.UpdateData(
                table: "Reporters",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "53895128-f998-4b82-bc4a-3a3582c37d4e", "AQAAAAEAACcQAAAAEDXB30gljjb1GBnWIvVXb4zfD+EdkSa6hhCKwgWLETJa26xTJxd/hJIlQDKD/fg2Aw==" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 29, 20, 12, 49, 404, DateTimeKind.Utc).AddTicks(8173), new DateTime(2023, 5, 29, 20, 12, 49, 404, DateTimeKind.Utc).AddTicks(8178) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 28, 20, 12, 49, 404, DateTimeKind.Utc).AddTicks(8180), new DateTime(2023, 5, 27, 20, 12, 49, 404, DateTimeKind.Utc).AddTicks(8185) });
        }
    }
}
