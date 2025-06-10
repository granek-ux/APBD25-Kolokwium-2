using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD25_Kolokwium_2.Migrations
{
    /// <inheritdoc />
    public partial class up : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Race",
                keyColumn: "RaceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 6, 10, 17, 13, 29, 576, DateTimeKind.Local).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 1,
                column: "LengthInKm",
                value: 5.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Race",
                keyColumn: "RaceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 6, 10, 17, 1, 45, 879, DateTimeKind.Local).AddTicks(2499));

            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "TrackId",
                keyValue: 1,
                column: "LengthInKm",
                value: 5.2000000000000002);
        }
    }
}
