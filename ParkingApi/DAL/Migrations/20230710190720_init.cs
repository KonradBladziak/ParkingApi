using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Miasto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Wojewodztwo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miasto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opiekun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opiekun", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdMiasta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parking_Miasto_IdMiasta",
                        column: x => x.IdMiasta,
                        principalTable: "Miasto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Miejsce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingId = table.Column<int>(type: "int", nullable: false),
                    MiejsceInwalidzkieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miejsce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Miejsce_Parking_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "Parking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingOpiekun",
                columns: table => new
                {
                    OpiekunowieId = table.Column<int>(type: "int", nullable: false),
                    ParkingiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingOpiekun", x => new { x.OpiekunowieId, x.ParkingiId });
                    table.ForeignKey(
                        name: "FK_ParkingOpiekun_Opiekun_OpiekunowieId",
                        column: x => x.OpiekunowieId,
                        principalTable: "Opiekun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingOpiekun_Parking_ParkingiId",
                        column: x => x.ParkingiId,
                        principalTable: "Parking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MiejsceInwalidzkie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RozmiarMiejsca = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IdMiejsca = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiejsceInwalidzkie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiejsceInwalidzkie_Miejsce_IdMiejsca",
                        column: x => x.IdMiejsca,
                        principalTable: "Miejsce",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Od = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Do = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMiejsca = table.Column<int>(type: "int", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezerwacja_Miejsce_IdMiejsca",
                        column: x => x.IdMiejsca,
                        principalTable: "Miejsce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Miasto",
                columns: new[] { "Id", "Nazwa", "Wojewodztwo" },
                values: new object[,]
                {
                    { 1, "Katowice", "Slaskie" },
                    { 2, "Chorzow", "Slaskie" },
                    { 3, "Bytom", "Slaskie" }
                });

            migrationBuilder.InsertData(
                table: "Opiekun",
                columns: new[] { "Id", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Michał", "Czajkowski" },
                    { 2, "Konrad", "Bladziak" }
                });

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

            migrationBuilder.InsertData(
                table: "Miejsce",
                columns: new[] { "Id", "MiejsceInwalidzkieId", "ParkingId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
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

            migrationBuilder.CreateIndex(
                name: "IX_Miejsce_ParkingId",
                table: "Miejsce",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_MiejsceInwalidzkie_IdMiejsca",
                table: "MiejsceInwalidzkie",
                column: "IdMiejsca",
                unique: true,
                filter: "[IdMiejsca] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Parking_IdMiasta",
                table: "Parking",
                column: "IdMiasta");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingOpiekun_ParkingiId",
                table: "ParkingOpiekun",
                column: "ParkingiId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacja_IdMiejsca",
                table: "Rezerwacja",
                column: "IdMiejsca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiejsceInwalidzkie");

            migrationBuilder.DropTable(
                name: "ParkingOpiekun");

            migrationBuilder.DropTable(
                name: "Rezerwacja");

            migrationBuilder.DropTable(
                name: "Opiekun");

            migrationBuilder.DropTable(
                name: "Miejsce");

            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "Miasto");
        }
    }
}
