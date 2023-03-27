using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class PlaceDATA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Miejsce",
                columns: new[] { "Id", "MiejsceInwalidzkieId", "ParkingId" },
                values: new object[,]
                {
                    { 2, null, 3 },
                    { 3, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "MiejsceInwalidzkie",
                columns: new[] { "Id", "IdMiejsca", "RozmiarMiejsca" },
                values: new object[] { 1, 2, 15m });

            migrationBuilder.InsertData(
                table: "Rezerwacja",
                columns: new[] { "Id", "Do", "IdMiejsca", "Imie", "Nazwisko", "Od" },
                values: new object[] { 1, new DateTime(2023, 7, 12, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, "Maciej", "Grzybowski", new DateTime(2023, 7, 12, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Miejsce",
                columns: new[] { "Id", "MiejsceInwalidzkieId", "ParkingId" },
                values: new object[] { 1, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Miejsce",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Miejsce",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rezerwacja",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MiejsceInwalidzkie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Miejsce",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
