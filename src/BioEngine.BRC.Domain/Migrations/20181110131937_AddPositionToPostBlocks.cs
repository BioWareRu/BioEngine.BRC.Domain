using Microsoft.EntityFrameworkCore.Migrations;

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class AddPositionToPostBlocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "PostBlocks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "PostBlocks");
        }
    }
}
