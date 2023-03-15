using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace logistic_app_api.Migrations
{
    public partial class cars_trailers_ins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BlrInsuranceDate",
                table: "Trailers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "GCInsuranceDate",
                table: "Trailers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TODate",
                table: "Trailers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "VinNumber",
                table: "Trailers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BlrInsuranceDate",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "GCInsuranceDate",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TODate",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "VinNumber",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlrInsuranceDate",
                table: "Trailers");

            migrationBuilder.DropColumn(
                name: "GCInsuranceDate",
                table: "Trailers");

            migrationBuilder.DropColumn(
                name: "TODate",
                table: "Trailers");

            migrationBuilder.DropColumn(
                name: "VinNumber",
                table: "Trailers");

            migrationBuilder.DropColumn(
                name: "BlrInsuranceDate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "GCInsuranceDate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TODate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "VinNumber",
                table: "Cars");
        }
    }
}
