using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.DAL.Migrations
{
    public partial class AddingLogoForCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Countries");
        }
    }
}
