using Microsoft.EntityFrameworkCore.Migrations;

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class storage_items_in_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_StorageItems_LogoId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_StorageItems_LogoSmallId",
                table: "Sections");

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
                type: "jsonb");

            migrationBuilder.AddColumn<string>(
                name: "LogoSmall",
                table: "Sections",
                type: "jsonb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
