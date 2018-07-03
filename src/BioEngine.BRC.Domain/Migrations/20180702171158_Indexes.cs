using Microsoft.EntityFrameworkCore.Migrations;

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sections_IsPublished",
                table: "Sections",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SiteIds",
                table: "Sections",
                column: "SiteIds");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Url",
                table: "Sections",
                column: "Url");

            migrationBuilder.CreateIndex(
                name: "IX_Content_IsPublished",
                table: "Content",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Content_SectionIds",
                table: "Content",
                column: "SectionIds");

            migrationBuilder.CreateIndex(
                name: "IX_Content_SiteIds",
                table: "Content",
                column: "SiteIds");

            migrationBuilder.CreateIndex(
                name: "IX_Content_TagIds",
                table: "Content",
                column: "TagIds");

            migrationBuilder.CreateIndex(
                name: "IX_Content_Type",
                table: "Content",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Content_Url",
                table: "Content",
                column: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sections_IsPublished",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_SiteIds",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_Url",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Content_IsPublished",
                table: "Content");

            migrationBuilder.DropIndex(
                name: "IX_Content_SectionIds",
                table: "Content");

            migrationBuilder.DropIndex(
                name: "IX_Content_SiteIds",
                table: "Content");

            migrationBuilder.DropIndex(
                name: "IX_Content_TagIds",
                table: "Content");

            migrationBuilder.DropIndex(
                name: "IX_Content_Type",
                table: "Content");

            migrationBuilder.DropIndex(
                name: "IX_Content_Url",
                table: "Content");
        }
    }
}
