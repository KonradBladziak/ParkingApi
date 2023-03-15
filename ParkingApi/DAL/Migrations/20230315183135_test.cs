using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
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
                name: "OpiekunParking",
                columns: table => new
                {
                    OpiekunowieId = table.Column<int>(type: "int", nullable: false),
                    ParkingiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpiekunParking", x => new { x.OpiekunowieId, x.ParkingiId });
                    table.ForeignKey(
                        name: "FK_OpiekunParking_Opiekun_OpiekunowieId",
                        column: x => x.OpiekunowieId,
                        principalTable: "Opiekun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpiekunParking_Parking_ParkingiId",
                        column: x => x.ParkingiId,
                        principalTable: "Parking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Miejsce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inwalidzkie = table.Column<bool>(type: "bit", nullable: false),
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
                name: "MiejsceInwalidzkie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RozmiarMiejsca = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdMiejsca = table.Column<int>(type: "int", nullable: true),
                    Miejsce = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiejsceInwalidzkie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiejsceInwalidzkie_Miejsce_Miejsce",
                        column: x => x.Miejsce,
                        principalTable: "Miejsce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Miejsce_MiejsceInwalidzkieId",
                table: "Miejsce",
                column: "MiejsceInwalidzkieId");

            migrationBuilder.CreateIndex(
                name: "IX_Miejsce_ParkingId",
                table: "Miejsce",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_MiejsceInwalidzkie_Miejsce",
                table: "MiejsceInwalidzkie",
                column: "Miejsce",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpiekunParking_ParkingiId",
                table: "OpiekunParking",
                column: "ParkingiId");

            migrationBuilder.CreateIndex(
                name: "IX_Parking_IdMiasta",
                table: "Parking",
                column: "IdMiasta");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacja_IdMiejsca",
                table: "Rezerwacja",
                column: "IdMiejsca");

            migrationBuilder.AddForeignKey(
                name: "FK_Miejsce_MiejsceInwalidzkie_MiejsceInwalidzkieId",
                table: "Miejsce",
                column: "MiejsceInwalidzkieId",
                principalTable: "MiejsceInwalidzkie",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miejsce_MiejsceInwalidzkie_MiejsceInwalidzkieId",
                table: "Miejsce");

            migrationBuilder.DropTable(
                name: "OpiekunParking");

            migrationBuilder.DropTable(
                name: "Rezerwacja");

            migrationBuilder.DropTable(
                name: "Opiekun");

            migrationBuilder.DropTable(
                name: "MiejsceInwalidzkie");

            migrationBuilder.DropTable(
                name: "Miejsce");

            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "Miasto");
        }
    }
}
