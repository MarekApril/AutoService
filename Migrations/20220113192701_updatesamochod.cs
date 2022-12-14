using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoServis.Migrations
{
    public partial class updatesamochod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Samochody",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Samochody");
        }
    }
}
