using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.DAL.Migrations
{
    public partial class AddingOrderColumnInDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "DepartMents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "DepartMents");
        }
    }
}
