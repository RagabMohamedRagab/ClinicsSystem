using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.DAL.Migrations
{
    public partial class AddingMaritalStausTableToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatusId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ArName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CraetedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MaritalStatusId",
                table: "Patients",
                column: "MaritalStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MaritalStatuses_MaritalStatusId",
                table: "Patients",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MaritalStatuses_MaritalStatusId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MaritalStatusId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MaritalStatusId",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
