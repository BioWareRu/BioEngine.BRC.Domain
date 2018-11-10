using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class SwitchToBlockContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    DatePublished = table.Column<DateTimeOffset>(nullable: true),
                    SiteIds = table.Column<int[]>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    IsPinned = table.Column<bool>(nullable: false),
                    SectionIds = table.Column<int[]>(nullable: true),
                    TagIds = table.Column<int[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Data = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostBlocks_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostBlocks_PostId",
                table: "PostBlocks",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IsPublished",
                table: "Posts",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SectionIds",
                table: "Posts",
                column: "SectionIds");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SiteIds",
                table: "Posts",
                column: "SiteIds");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TagIds",
                table: "Posts",
                column: "TagIds");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Url",
                table: "Posts",
                column: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostBlocks");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTimeOffset>(nullable: false),
                    DatePublished = table.Column<DateTimeOffset>(nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(nullable: false),
                    IsPinned = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    SectionIds = table.Column<int[]>(nullable: true),
                    SiteIds = table.Column<int[]>(nullable: true),
                    TagIds = table.Column<int[]>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Data = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
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
        }
    }
}
