using Microsoft.EntityFrameworkCore.Migrations;

namespace BioEngine.BRC.Domain.Migrations
{
    // ReSharper disable once InconsistentNaming
    public partial class Add_SiteId_To_Settings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "Pages");

            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sites",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "Sites",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "Pages",
                nullable: true);
        }
    }
}
