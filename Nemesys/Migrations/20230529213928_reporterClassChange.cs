using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    /// <inheritdoc />
    public partial class reporterClassChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reporters",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00f53e0e-6935-4e9e-829a-81593a611e8a", "AQAAAAEAACcQAAAAEFhiu9yxsLFjOxLif20Jd+PDP+TlJ9YpI4eyiH5IkTUV31nituN/Jt8IT4PSsJ1OCA==" });

            migrationBuilder.UpdateData(
                table: "Reporters",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7793656f-a52f-4c25-9d70-5f2f9b545f7d", "AQAAAAEAACcQAAAAEIDB5INfSfCczF9leV+C87nBRrV1HcjYx7vbtu+ZlCMxureS6IUkiI9QL7r1zZnjkA==" });

            migrationBuilder.UpdateData(
                table: "Reporters",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e565980-2c7f-42b9-b5ca-4165b35c125d", "AQAAAAEAACcQAAAAEByZLXNpLnQbOt3th9AoAhndQGmYJc3VB8en1jmyovacxkdaQ0kviCMKlxzKRAwhOQ==" });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 29, 21, 39, 28, 618, DateTimeKind.Utc).AddTicks(7911), new DateTime(2023, 5, 29, 21, 39, 28, 618, DateTimeKind.Utc).AddTicks(7913) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfReport", "DateOfSpotting" },
                values: new object[] { new DateTime(2023, 5, 28, 21, 39, 28, 618, DateTimeKind.Utc).AddTicks(7920), new DateTime(2023, 5, 27, 21, 39, 28, 618, DateTimeKind.Utc).AddTicks(7926) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Reporters",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f41f6f26-5e2b-4005-a102-bb43a5a68be6", "AQAAAAEAACcQAAAAEBW5lSiLY6BwK8uOfBe2PK1uzI66k+BgaAF8lWMFybDE3jsORoszs/8CA/qSmSHW+A==" });

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
    }
}
