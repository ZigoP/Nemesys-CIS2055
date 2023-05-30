using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    /// <inheritdoc />
    public partial class dbContextChanges3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reporters",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "97de1788-66e8-491e-adb4-28364d5022b4", "AQAAAAEAACcQAAAAEKr1Z9nlO/kvmg9r6VJuur9cKwdwnymm69N2prDddM9fCqgHCSx82/ADKDqP3Ig0sw==" });

            migrationBuilder.UpdateData(
                table: "Reporters",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f0de6f63-2ca9-4429-a797-ed4a5e8ccdf4", "AQAAAAEAACcQAAAAEAkEXieNgY+5YMweKPbmKQAJvz2tvfy5p0oxDGThY63BIZwO/fkiEp/Rt/fTbMZPGw==" });

            migrationBuilder.InsertData(
                table: "Reporters",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ReportersRanking", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { 12, 0, "f41f6f26-5e2b-4005-a102-bb43a5a68be6", "Investigator", "dasd@gams.sca", true, false, null, "First", "DASD@GAMS.SCA", "DASD@GAMS.SCA", "AQAAAAEAACcQAAAAEBW5lSiLY6BwK8uOfBe2PK1uzI66k+BgaAF8lWMFybDE3jsORoszs/8CA/qSmSHW+A==", "1234567890", false, 3, null, "Investigator", false, "dasd@gams.sca" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 29, 21, 27, 39, 394, DateTimeKind.Utc).AddTicks(3455), new DateTime(2023, 5, 29, 21, 27, 39, 394, DateTimeKind.Utc).AddTicks(3457) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 28, 21, 27, 39, 394, DateTimeKind.Utc).AddTicks(3460), new DateTime(2023, 5, 27, 21, 27, 39, 394, DateTimeKind.Utc).AddTicks(3468) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reporters",
                keyColumn: "Id",
                keyValue: 12);

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
    }
}
