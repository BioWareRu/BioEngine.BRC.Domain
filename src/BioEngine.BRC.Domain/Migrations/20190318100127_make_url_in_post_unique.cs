using Microsoft.EntityFrameworkCore.Migrations;
// ReSharper disable All

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class make_url_in_post_unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posts_Url",
                table: "Posts");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Url",
                table: "Posts",
                column: "Url",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posts_Url",
                table: "Posts");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Url",
                table: "Posts",
                column: "Url");
        }
    }
}
