using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class add_post_versioning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    DatePublished = table.Column<DateTimeOffset>(nullable: true),
                    PostId = table.Column<Guid>(nullable: false),
                    Data = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostVersions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostVersions");
        }
    }
}
