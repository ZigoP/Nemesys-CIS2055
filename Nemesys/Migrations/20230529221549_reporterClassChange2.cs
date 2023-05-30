using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    /// <inheritdoc />
    public partial class reporterClassChange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstInvestigatorId",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "6826e668-b57f-43b8-aeee-0d75501c4323", "dasd@gams.sca", "AQAAAAEAACcQAAAAEGo/uKbusQlja+UnGFWZNuWLauAj74f7wlYm8bqZpq4YcI4BEFA7EZpcVdJPUPwadA==", "1234567890", "6f14ef54-f8b8-4611-b204-9d63f4107979" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstReporterId",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "6ffe1548-bc91-4f8e-b00e-33370790f688", "adas@gams.sca", "AQAAAAEAACcQAAAAEMVuoKKlhdwA3aGbohqMp2vKNxwgbdH4MX37S8CI1GxHx7h6ztVvtObpwJN9KlHkXg==", "1234567890", "002d0d10-8213-4c1c-ab82-5b9e0c6d3d29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "secondReporterId",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "53223edc-8e81-4245-9ba4-71c9602a4e40", "basd@gams.sca", "AQAAAAEAACcQAAAAEDB1X69+MyrARvOrpf0qOQqBQNIRdkKLdp71o4B3/9vWkKRFgqxz0FpFiaU96Xe1kA==", "1234567890", "55039949-ae76-4427-ad53-27bf00fb0510" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 29, 22, 15, 49, 539, DateTimeKind.Utc).AddTicks(6835), new DateTime(2023, 5, 29, 22, 15, 49, 539, DateTimeKind.Utc).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 28, 22, 15, 49, 539, DateTimeKind.Utc).AddTicks(6849), new DateTime(2023, 5, 27, 22, 15, 49, 539, DateTimeKind.Utc).AddTicks(6854) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstInvestigatorId",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "6e6fe156-adec-40c0-9818-580aaaf56ada", null, "AQAAAAEAACcQAAAAEKGG/pQWkuGmWG+voaOdzBmKVLX3wisjowtMrxgEy7lZVvy4dG5lKt7Qy1DF+0vvqQ==", null, "3e835d16-51dc-41bd-a58c-a4a836ac6efe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "firstReporterId",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "f292fcf3-ed2f-48a8-a5df-6de7f8c990b1", null, "AQAAAAEAACcQAAAAEOHys+GV7oTS22SXOJrLJcnALYm96dQy+I3r88Z03kqS9/Of4GTQF155jBYCi7UGWw==", null, "7547ad37-ff53-4795-ab9e-99a883478e38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "secondReporterId",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "ce36f31a-ff9a-4ba7-8703-acc2e5ac2de7", null, "AQAAAAEAACcQAAAAEPtiNAXWAEarQKWupKort6fFaAKbndKODozvmuyMGmygHGv6nmYLkS2Q4hGil/4u6g==", null, "255decfc-f48c-474e-a26a-9e3c90c286b2" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 29, 22, 13, 57, 274, DateTimeKind.Utc).AddTicks(3460), new DateTime(2023, 5, 29, 22, 13, 57, 274, DateTimeKind.Utc).AddTicks(3464) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 28, 22, 13, 57, 274, DateTimeKind.Utc).AddTicks(3468), new DateTime(2023, 5, 27, 22, 13, 57, 274, DateTimeKind.Utc).AddTicks(3472) });
        }
    }
}
