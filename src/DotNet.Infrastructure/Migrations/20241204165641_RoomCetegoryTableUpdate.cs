using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoomCetegoryTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "core",
                table: "RoomCategories",
                newName: "RoomCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomCategoryId",
                schema: "core",
                table: "RoomCategories",
                newName: "Id");
        }
    }
}
