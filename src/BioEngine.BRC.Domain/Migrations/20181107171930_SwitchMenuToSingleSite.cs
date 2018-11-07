using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class SwitchMenuToSingleSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteIds",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "Menus",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Menus");

            migrationBuilder.AddColumn<int[]>(
                name: "SiteIds",
                table: "Menus",
                nullable: true);
        }
    }
}
