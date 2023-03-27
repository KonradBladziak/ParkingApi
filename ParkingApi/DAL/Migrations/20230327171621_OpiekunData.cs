using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class OpiekunData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Opiekun",
                columns: new[] { "Id", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Michał", "Czajkowski" },
                    { 2, "Konrad", "Bladziak" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Opiekun",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Opiekun",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
