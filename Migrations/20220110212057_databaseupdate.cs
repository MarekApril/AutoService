using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoServis.Migrations
{
    public partial class databaseupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontrahenci_Adresy_AdresId",
                table: "Kontrahenci");

            migrationBuilder.DropColumn(
                name: "IdAdres",
                table: "Kontrahenci");

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Kontrahenci",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kontrahenci_Adresy_AdresId",
                table: "Kontrahenci",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontrahenci_Adresy_AdresId",
                table: "Kontrahenci");

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Kontrahenci",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdAdres",
                table: "Kontrahenci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Kontrahenci_Adresy_AdresId",
                table: "Kontrahenci",
                column: "AdresId",
                principalTable: "Adresy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
