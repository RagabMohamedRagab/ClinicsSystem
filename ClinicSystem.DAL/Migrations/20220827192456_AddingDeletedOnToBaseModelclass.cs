using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicSystem.DAL.Migrations
{
    public partial class AddingDeletedOnToBaseModelclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "VisitTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Shifts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ServiceImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Rays",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PatientDrugs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PackageFeatures",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Package",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "FoodSystems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Drugs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "DepartMents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ClinicServices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Clinics",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ClinicPackages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ClinicImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Breaks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AppUserClinics",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Appointments",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "VisitTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ServiceImages");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Rays");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PatientDrugs");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PackageFeatures");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "FoodSystems");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "DepartMents");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ClinicServices");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ClinicPackages");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ClinicImages");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Breaks");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AppUserClinics");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Appointments");
        }
    }
}
