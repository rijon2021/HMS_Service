using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addIsActive_Hostel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "core",
                table: "Hostels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "core",
                table: "Hostels");
        }
    }
}
