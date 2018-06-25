using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    DatePublished = table.Column<DateTimeOffset>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsPinned = table.Column<bool>(nullable: false),
                    ForumTopicId = table.Column<int>(nullable: true),
                    ForumPostId = table.Column<int>(nullable: true),
                    CommentsCount = table.Column<int>(nullable: false),
                    SectionIds = table.Column<int[]>(nullable: true),
                    SiteIds = table.Column<int[]>(nullable: true),
                    Data = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    ForumId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Logo = table.Column<string>(type: "jsonb", nullable: false),
                    LogoSmall = table.Column<string>(type: "jsonb", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: false),
                    Keywords = table.Column<string>(nullable: true),
                    Hashtag = table.Column<string>(nullable: false),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    DatePublished = table.Column<DateTimeOffset>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    SiteIds = table.Column<int[]>(nullable: true),
                    Data = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    DatePublished = table.Column<DateTimeOffset>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Keywords = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
