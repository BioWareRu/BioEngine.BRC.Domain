using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioEngine.BRC.Domain.Migrations
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public partial class add_entity_fields_to_ContentBlocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateAdded",
                table: "ContentBlocks",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow
            );

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DatePublished",
                table: "ContentBlocks",
                nullable: true,
                defaultValue: DateTimeOffset.UtcNow);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "ContentBlocks",
                nullable: false,
                defaultValue: DateTimeOffset.UtcNow);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "ContentBlocks",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "ContentBlocks");

            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "ContentBlocks");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "ContentBlocks");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "ContentBlocks");
        }
    }
}
