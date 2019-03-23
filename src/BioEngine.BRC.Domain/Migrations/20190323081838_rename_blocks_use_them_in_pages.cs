using Microsoft.EntityFrameworkCore.Migrations;

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class rename_blocks_use_them_in_pages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostBlocks_Posts_PostId",
                table: "PostBlocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostBlocks",
                table: "PostBlocks");

            migrationBuilder.RenameTable(
                name: "PostBlocks",
                newName: "ContentBlocks");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "ContentBlocks",
                newName: "ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_PostBlocks_PostId",
                table: "ContentBlocks",
                newName: "IX_ContentBlocks_ContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentBlocks",
                table: "ContentBlocks",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentBlocks",
                table: "ContentBlocks");

            migrationBuilder.RenameTable(
                name: "ContentBlocks",
                newName: "PostBlocks");

            migrationBuilder.RenameColumn(
                name: "ContentId",
                table: "PostBlocks",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_ContentBlocks_ContentId",
                table: "PostBlocks",
                newName: "IX_PostBlocks_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostBlocks",
                table: "PostBlocks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostBlocks_Posts_PostId",
                table: "PostBlocks",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
