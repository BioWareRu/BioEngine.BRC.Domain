using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class CurrentState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(),
                    AuthorId = table.Column<int>(),
                    Title = table.Column<string>(),
                    Url = table.Column<string>(),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTimeOffset>(),
                    DateUpdated = table.Column<DateTimeOffset>(),
                    DatePublished = table.Column<DateTimeOffset>(nullable: true),
                    IsPublished = table.Column<bool>(),
                    IsPinned = table.Column<bool>(),
                    SectionIds = table.Column<int[]>(nullable: true),
                    SiteIds = table.Column<int[]>(nullable: true),
                    TagIds = table.Column<int[]>(nullable: true),
                    Data = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateAdded = table.Column<DateTimeOffset>(),
                    DateUpdated = table.Column<DateTimeOffset>(),
                    IsPublished = table.Column<bool>(),
                    DatePublished = table.Column<DateTimeOffset>(nullable: true),
                    SiteIds = table.Column<int[]>(nullable: true),
                    Title = table.Column<string>(),
                    Url = table.Column<string>(),
                    Text = table.Column<string>(),
                    Description = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(),
                    ParentId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(),
                    Url = table.Column<string>(),
                    Logo = table.Column<string>(type: "jsonb"),
                    LogoSmall = table.Column<string>(type: "jsonb"),
                    Description = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(),
                    Keywords = table.Column<string>(nullable: true),
                    Hashtag = table.Column<string>(),
                    DateAdded = table.Column<DateTimeOffset>(),
                    DateUpdated = table.Column<DateTimeOffset>(),
                    DatePublished = table.Column<DateTimeOffset>(nullable: true),
                    IsPublished = table.Column<bool>(),
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
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateAdded = table.Column<DateTimeOffset>(),
                    DateUpdated = table.Column<DateTimeOffset>(),
                    IsPublished = table.Column<bool>(),
                    DatePublished = table.Column<DateTimeOffset>(nullable: true),
                    Title = table.Column<string>(),
                    Url = table.Column<string>(),
                    Description = table.Column<string>(),
                    Keywords = table.Column<string>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateAdded = table.Column<DateTimeOffset>(),
                    DateUpdated = table.Column<DateTimeOffset>(),
                    IsPublished = table.Column<bool>(),
                    DatePublished = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
