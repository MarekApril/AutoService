using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoServis.Migrations
{
    public partial class updatesamochod2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImieKlienta",
                table: "Samochody",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NazwiskoKlienta",
                table: "Samochody",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonKlienta",
                table: "Samochody",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImieKlienta",
                table: "Samochody");

            migrationBuilder.DropColumn(
                name: "NazwiskoKlienta",
                table: "Samochody");

            migrationBuilder.DropColumn(
                name: "TelefonKlienta",
                table: "Samochody");
        }
    }
}
