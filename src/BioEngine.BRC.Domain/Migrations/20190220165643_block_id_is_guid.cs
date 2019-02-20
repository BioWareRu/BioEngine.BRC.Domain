using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BioEngine.BRC.Domain.Migrations
{
    public partial class block_id_is_guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION \"uuid-ossp\";");
            migrationBuilder.Sql("ALTER TABLE \"PostBlocks\" ALTER COLUMN \"Id\" TYPE uuid USING (uuid_generate_v4());");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"PostBlocks\" ALTER COLUMN \"Id\" TYPE int USING (0);");
        }
    }
}
