using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoServis.Migrations
{
    public partial class updatebase222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mechanicy_Adresy_AdresId",
                table: "Mechanicy");

            migrationBuilder.DropForeignKey(
                name: "FK_Samochody_Mechanicy_MechanikId",
                table: "Samochody");

            migrationBuilder.DropColumn(
                name: "IdMechanik",
                table: "Samochody");

            migrationBuilder.DropColumn(
                name: "IdAdresu",
                table: "Mechanicy");

            migrationBuilder.AlterColumn<int>(
                name: "MechanikId",
                table: "Samochody",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Mechanicy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mechanicy_Adresy_AdresId",
                table: "Mechanicy",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Samochody_Mechanicy_MechanikId",
                table: "Samochody",
                column: "MechanikId",
                principalTable: "Mechanicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mechanicy_Adresy_AdresId",
                table: "Mechanicy");

            migrationBuilder.DropForeignKey(
                name: "FK_Samochody_Mechanicy_MechanikId",
                table: "Samochody");

            migrationBuilder.AlterColumn<int>(
                name: "MechanikId",
                table: "Samochody",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdMechanik",
                table: "Samochody",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Mechanicy",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdAdresu",
                table: "Mechanicy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Mechanicy_Adresy_AdresId",
                table: "Mechanicy",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Samochody_Mechanicy_MechanikId",
                table: "Samochody",
                column: "MechanikId",
                principalTable: "Mechanicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
