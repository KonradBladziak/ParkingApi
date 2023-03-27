using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ParkingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parking",
                columns: new[] { "Id", "Adres", "IdMiasta", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Kolejowa 16", 1, "Slaski" },
                    { 2, "Wesoła 21", 2, "Chorzowski" },
                    { 3, "Jana Pawła II 51", 1, "Na zakręcie" },
                    { 4, "Grzybowa 11", 3, "Przy galerii" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parking",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parking",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parking",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parking",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
