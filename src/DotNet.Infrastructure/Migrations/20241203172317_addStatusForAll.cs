using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addStatusForAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomCategory",
                schema: "core",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Amenities",
                schema: "core",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "core",
                table: "Hostels");

            migrationBuilder.AddColumn<int>(
                name: "RoomCategoryId",
                schema: "core",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                schema: "core",
                table: "Rooms",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                schema: "core",
                table: "Hostels",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Amenities",
                schema: "core",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                schema: "core",
                table: "Branches",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                schema: "core",
                table: "Beds",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "RoomCategories",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomCategoryId",
                schema: "core",
                table: "Rooms",
                column: "RoomCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomCategories_RoomCategoryId",
                schema: "core",
                table: "Rooms",
                column: "RoomCategoryId",
                principalSchema: "core",
                principalTable: "RoomCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomCategories_RoomCategoryId",
                schema: "core",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomCategories",
                schema: "core");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomCategoryId",
                schema: "core",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomCategoryId",
                schema: "core",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "core",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "core",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "Amenities",
                schema: "core",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "core",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "core",
                table: "Beds");

            migrationBuilder.AddColumn<string>(
                name: "RoomCategory",
                schema: "core",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Amenities",
                schema: "core",
                table: "Hostels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "core",
                table: "Hostels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
