using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServerApp.Migrations
{
    /// <inheritdoc />
    public partial class addTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "server_schema");

            migrationBuilder.CreateTable(
                name: "rooms",
                schema: "server_schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                schema: "server_schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RoomId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_messages_rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "server_schema",
                        principalTable: "rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user_room_links",
                schema: "server_schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_room_links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_room_links_rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "server_schema",
                        principalTable: "rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_messages_RoomId",
                schema: "server_schema",
                table: "messages",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_Code",
                schema: "server_schema",
                table: "rooms",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_room_links_RoomId",
                schema: "server_schema",
                table: "user_room_links",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_user_room_links_Username_RoomId",
                schema: "server_schema",
                table: "user_room_links",
                columns: new[] { "Username", "RoomId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messages",
                schema: "server_schema");

            migrationBuilder.DropTable(
                name: "user_room_links",
                schema: "server_schema");

            migrationBuilder.DropTable(
                name: "rooms",
                schema: "server_schema");
        }
    }
}
