using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CityDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Miasto",
                columns: new[] { "Id", "Nazwa", "Wojewodztwo" },
                values: new object[,]
                {
                    { 1, "Katowice", "Slaskie" },
                    { 2, "Chorzow", "Slaskie" },
                    { 3, "Bytom", "Slaskie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Miasto",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Miasto",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Miasto",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
