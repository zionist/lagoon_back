using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace lagoon_back.Migrations
{
    public partial class InitialApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.CreateTable(
                name: "application_user",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    password = table.Column<string>(nullable: false),
                    username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "flyway_schema_history",
                schema: "app",
                columns: table => new
                {
                    installed_rank = table.Column<int>(nullable: false),
                    checksum = table.Column<int>(nullable: true),
                    description = table.Column<string>(nullable: false),
                    execution_time = table.Column<int>(nullable: false),
                    installed_by = table.Column<string>(nullable: false),
                    installed_on = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    script = table.Column<string>(nullable: false),
                    success = table.Column<bool>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flyway_schema_history", x => x.installed_rank);
                });

            migrationBuilder.CreateTable(
                name: "item_category",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    image_path = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "application_user_role",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_user_role", x => x.id);
                    table.ForeignKey(
                        name: "application_user_role_userid_fkey",
                        column: x => x.userid,
                        principalSchema: "app",
                        principalTable: "application_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    category_id = table.Column<int>(nullable: false),
                    image_path = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    specification = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.id);
                    table.ForeignKey(
                        name: "item_category_id_fkey",
                        column: x => x.category_id,
                        principalSchema: "app",
                        principalTable: "item_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "application_user_username_key",
                schema: "app",
                table: "application_user",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "application_user_role_name_key",
                schema: "app",
                table: "application_user_role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_application_user_role_userid",
                schema: "app",
                table: "application_user_role",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "flyway_schema_history_s_idx",
                schema: "app",
                table: "flyway_schema_history",
                column: "success");

            migrationBuilder.CreateIndex(
                name: "IX_item_category_id",
                schema: "app",
                table: "item",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "item_image_path_key",
                schema: "app",
                table: "item",
                column: "image_path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "item_name_key",
                schema: "app",
                table: "item",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "item_category_image_path_key",
                schema: "app",
                table: "item_category",
                column: "image_path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "item_category_name_key",
                schema: "app",
                table: "item_category",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "application_user_role",
                schema: "app");

            migrationBuilder.DropTable(
                name: "flyway_schema_history",
                schema: "app");

            migrationBuilder.DropTable(
                name: "item",
                schema: "app");

            migrationBuilder.DropTable(
                name: "application_user",
                schema: "app");

            migrationBuilder.DropTable(
                name: "item_category",
                schema: "app");
        }
    }
}
