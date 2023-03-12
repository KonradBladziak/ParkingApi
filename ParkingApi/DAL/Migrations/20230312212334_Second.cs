using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Miasta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Wojewodztwo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miasta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opiekunowie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opiekunowie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parkingi",
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
                    table.PrimaryKey("PK_Parkingi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parkingi_Miasta_IdMiasta",
                        column: x => x.IdMiasta,
                        principalTable: "Miasta",
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
                        name: "FK_OpiekunParking_Opiekunowie_OpiekunowieId",
                        column: x => x.OpiekunowieId,
                        principalTable: "Opiekunowie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpiekunParking_Parkingi_ParkingiId",
                        column: x => x.ParkingiId,
                        principalTable: "Parkingi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Miejsca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inwalidzkie = table.Column<bool>(type: "bit", nullable: false),
                    MiejsceInwalidzkieId = table.Column<int>(type: "int", nullable: true),
                    ParkingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miejsca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Miejsca_Parkingi_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "Parkingi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MiejscaInwalidzkie",
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
                    table.PrimaryKey("PK_MiejscaInwalidzkie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiejscaInwalidzkie_Miejsca_Miejsce",
                        column: x => x.Miejsce,
                        principalTable: "Miejsca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMiejsca = table.Column<int>(type: "int", nullable: false),
                    Od = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Do = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Miejsca_IdMiejsca",
                        column: x => x.IdMiejsca,
                        principalTable: "Miejsca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Miejsca_MiejsceInwalidzkieId",
                table: "Miejsca",
                column: "MiejsceInwalidzkieId");

            migrationBuilder.CreateIndex(
                name: "IX_Miejsca_ParkingId",
                table: "Miejsca",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_MiejscaInwalidzkie_Miejsce",
                table: "MiejscaInwalidzkie",
                column: "Miejsce",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpiekunParking_ParkingiId",
                table: "OpiekunParking",
                column: "ParkingiId");

            migrationBuilder.CreateIndex(
                name: "IX_Parkingi_IdMiasta",
                table: "Parkingi",
                column: "IdMiasta");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_IdMiejsca",
                table: "Rezerwacje",
                column: "IdMiejsca");

            migrationBuilder.AddForeignKey(
                name: "FK_Miejsca_MiejscaInwalidzkie_MiejsceInwalidzkieId",
                table: "Miejsca",
                column: "MiejsceInwalidzkieId",
                principalTable: "MiejscaInwalidzkie",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miejsca_MiejscaInwalidzkie_MiejsceInwalidzkieId",
                table: "Miejsca");

            migrationBuilder.DropTable(
                name: "OpiekunParking");

            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Opiekunowie");

            migrationBuilder.DropTable(
                name: "MiejscaInwalidzkie");

            migrationBuilder.DropTable(
                name: "Miejsca");

            migrationBuilder.DropTable(
                name: "Parkingi");

            migrationBuilder.DropTable(
                name: "Miasta");
        }
    }
}
