using Microsoft.EntityFrameworkCore.Migrations;

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class add_change_author_id_to_post_versioning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChangeAuthorId",
                table: "PostVersions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeAuthorId",
                table: "PostVersions");
        }
    }
}
