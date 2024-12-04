using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace foraneoApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EventMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    eventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    urlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.eventId);
                    table.ForeignKey(
                        name: "FK_Events_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_categoryId",
                table: "Events",
                column: "categoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
