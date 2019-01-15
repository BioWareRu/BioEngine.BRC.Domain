using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class RedoStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "LogoSmall",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "LogoId",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LogoSmallId",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StorageItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    DatePublished = table.Column<DateTimeOffset>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileSize = table.Column<long>(nullable: false),
                    PublicUri = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    PictureInfo = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_LogoId",
                table: "Sections",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_LogoSmallId",
                table: "Sections",
                column: "LogoSmallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_StorageItems_LogoId",
                table: "Sections",
                column: "LogoId",
                principalTable: "StorageItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_StorageItems_LogoSmallId",
                table: "Sections",
                column: "LogoSmallId",
                principalTable: "StorageItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_StorageItems_LogoId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_StorageItems_LogoSmallId",
                table: "Sections");

            migrationBuilder.DropTable(
                name: "StorageItems");

            migrationBuilder.DropIndex(
                name: "IX_Sections_LogoId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_LogoSmallId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "LogoSmallId",
                table: "Sections");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Sections",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoSmall",
                table: "Sections",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }
    }
}
