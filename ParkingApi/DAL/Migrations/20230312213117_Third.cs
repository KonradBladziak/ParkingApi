using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miejsca_MiejscaInwalidzkie_MiejsceInwalidzkieId",
                table: "Miejsca");

            migrationBuilder.DropForeignKey(
                name: "FK_Miejsca_Parkingi_ParkingId",
                table: "Miejsca");

            migrationBuilder.DropForeignKey(
                name: "FK_MiejscaInwalidzkie_Miejsca_Miejsce",
                table: "MiejscaInwalidzkie");

            migrationBuilder.DropForeignKey(
                name: "FK_OpiekunParking_Opiekunowie_OpiekunowieId",
                table: "OpiekunParking");

            migrationBuilder.DropForeignKey(
                name: "FK_OpiekunParking_Parkingi_ParkingiId",
                table: "OpiekunParking");

            migrationBuilder.DropForeignKey(
                name: "FK_Parkingi_Miasta_IdMiasta",
                table: "Parkingi");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Miejsca_IdMiejsca",
                table: "Rezerwacje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezerwacje",
                table: "Rezerwacje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parkingi",
                table: "Parkingi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Opiekunowie",
                table: "Opiekunowie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MiejscaInwalidzkie",
                table: "MiejscaInwalidzkie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Miejsca",
                table: "Miejsca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Miasta",
                table: "Miasta");

            migrationBuilder.RenameTable(
                name: "Rezerwacje",
                newName: "Rezerwacja");

            migrationBuilder.RenameTable(
                name: "Parkingi",
                newName: "Parking");

            migrationBuilder.RenameTable(
                name: "Opiekunowie",
                newName: "Opiekun");

            migrationBuilder.RenameTable(
                name: "MiejscaInwalidzkie",
                newName: "MiejsceInwalidzkie");

            migrationBuilder.RenameTable(
                name: "Miejsca",
                newName: "Miejsce");

            migrationBuilder.RenameTable(
                name: "Miasta",
                newName: "Miasto");

            migrationBuilder.RenameIndex(
                name: "IX_Rezerwacje_IdMiejsca",
                table: "Rezerwacja",
                newName: "IX_Rezerwacja_IdMiejsca");

            migrationBuilder.RenameIndex(
                name: "IX_Parkingi_IdMiasta",
                table: "Parking",
                newName: "IX_Parking_IdMiasta");

            migrationBuilder.RenameIndex(
                name: "IX_MiejscaInwalidzkie_Miejsce",
                table: "MiejsceInwalidzkie",
                newName: "IX_MiejsceInwalidzkie_Miejsce");

            migrationBuilder.RenameIndex(
                name: "IX_Miejsca_ParkingId",
                table: "Miejsce",
                newName: "IX_Miejsce_ParkingId");

            migrationBuilder.RenameIndex(
                name: "IX_Miejsca_MiejsceInwalidzkieId",
                table: "Miejsce",
                newName: "IX_Miejsce_MiejsceInwalidzkieId");

            migrationBuilder.AlterColumn<int>(
                name: "ParkingId",
                table: "Miejsce",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezerwacja",
                table: "Rezerwacja",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parking",
                table: "Parking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opiekun",
                table: "Opiekun",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MiejsceInwalidzkie",
                table: "MiejsceInwalidzkie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Miejsce",
                table: "Miejsce",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Miasto",
                table: "Miasto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Miejsce_MiejsceInwalidzkie_MiejsceInwalidzkieId",
                table: "Miejsce",
                column: "MiejsceInwalidzkieId",
                principalTable: "MiejsceInwalidzkie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Miejsce_Parking_ParkingId",
                table: "Miejsce",
                column: "ParkingId",
                principalTable: "Parking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MiejsceInwalidzkie_Miejsce_Miejsce",
                table: "MiejsceInwalidzkie",
                column: "Miejsce",
                principalTable: "Miejsce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpiekunParking_Opiekun_OpiekunowieId",
                table: "OpiekunParking",
                column: "OpiekunowieId",
                principalTable: "Opiekun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpiekunParking_Parking_ParkingiId",
                table: "OpiekunParking",
                column: "ParkingiId",
                principalTable: "Parking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parking_Miasto_IdMiasta",
                table: "Parking",
                column: "IdMiasta",
                principalTable: "Miasto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacja_Miejsce_IdMiejsca",
                table: "Rezerwacja",
                column: "IdMiejsca",
                principalTable: "Miejsce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miejsce_MiejsceInwalidzkie_MiejsceInwalidzkieId",
                table: "Miejsce");

            migrationBuilder.DropForeignKey(
                name: "FK_Miejsce_Parking_ParkingId",
                table: "Miejsce");

            migrationBuilder.DropForeignKey(
                name: "FK_MiejsceInwalidzkie_Miejsce_Miejsce",
                table: "MiejsceInwalidzkie");

            migrationBuilder.DropForeignKey(
                name: "FK_OpiekunParking_Opiekun_OpiekunowieId",
                table: "OpiekunParking");

            migrationBuilder.DropForeignKey(
                name: "FK_OpiekunParking_Parking_ParkingiId",
                table: "OpiekunParking");

            migrationBuilder.DropForeignKey(
                name: "FK_Parking_Miasto_IdMiasta",
                table: "Parking");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacja_Miejsce_IdMiejsca",
                table: "Rezerwacja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezerwacja",
                table: "Rezerwacja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parking",
                table: "Parking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Opiekun",
                table: "Opiekun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MiejsceInwalidzkie",
                table: "MiejsceInwalidzkie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Miejsce",
                table: "Miejsce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Miasto",
                table: "Miasto");

            migrationBuilder.RenameTable(
                name: "Rezerwacja",
                newName: "Rezerwacje");

            migrationBuilder.RenameTable(
                name: "Parking",
                newName: "Parkingi");

            migrationBuilder.RenameTable(
                name: "Opiekun",
                newName: "Opiekunowie");

            migrationBuilder.RenameTable(
                name: "MiejsceInwalidzkie",
                newName: "MiejscaInwalidzkie");

            migrationBuilder.RenameTable(
                name: "Miejsce",
                newName: "Miejsca");

            migrationBuilder.RenameTable(
                name: "Miasto",
                newName: "Miasta");

            migrationBuilder.RenameIndex(
                name: "IX_Rezerwacja_IdMiejsca",
                table: "Rezerwacje",
                newName: "IX_Rezerwacje_IdMiejsca");

            migrationBuilder.RenameIndex(
                name: "IX_Parking_IdMiasta",
                table: "Parkingi",
                newName: "IX_Parkingi_IdMiasta");

            migrationBuilder.RenameIndex(
                name: "IX_MiejsceInwalidzkie_Miejsce",
                table: "MiejscaInwalidzkie",
                newName: "IX_MiejscaInwalidzkie_Miejsce");

            migrationBuilder.RenameIndex(
                name: "IX_Miejsce_ParkingId",
                table: "Miejsca",
                newName: "IX_Miejsca_ParkingId");

            migrationBuilder.RenameIndex(
                name: "IX_Miejsce_MiejsceInwalidzkieId",
                table: "Miejsca",
                newName: "IX_Miejsca_MiejsceInwalidzkieId");

            migrationBuilder.AlterColumn<int>(
                name: "ParkingId",
                table: "Miejsca",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezerwacje",
                table: "Rezerwacje",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parkingi",
                table: "Parkingi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opiekunowie",
                table: "Opiekunowie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MiejscaInwalidzkie",
                table: "MiejscaInwalidzkie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Miejsca",
                table: "Miejsca",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Miasta",
                table: "Miasta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Miejsca_MiejscaInwalidzkie_MiejsceInwalidzkieId",
                table: "Miejsca",
                column: "MiejsceInwalidzkieId",
                principalTable: "MiejscaInwalidzkie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Miejsca_Parkingi_ParkingId",
                table: "Miejsca",
                column: "ParkingId",
                principalTable: "Parkingi",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MiejscaInwalidzkie_Miejsca_Miejsce",
                table: "MiejscaInwalidzkie",
                column: "Miejsce",
                principalTable: "Miejsca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpiekunParking_Opiekunowie_OpiekunowieId",
                table: "OpiekunParking",
                column: "OpiekunowieId",
                principalTable: "Opiekunowie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpiekunParking_Parkingi_ParkingiId",
                table: "OpiekunParking",
                column: "ParkingiId",
                principalTable: "Parkingi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parkingi_Miasta_IdMiasta",
                table: "Parkingi",
                column: "IdMiasta",
                principalTable: "Miasta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Miejsca_IdMiejsca",
                table: "Rezerwacje",
                column: "IdMiejsca",
                principalTable: "Miejsca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
