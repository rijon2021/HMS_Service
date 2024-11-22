using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBranch_Email_Phone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactDetails",
                schema: "core",
                table: "Branches",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "core",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "core",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "Phone",
                schema: "core",
                table: "Branches",
                newName: "ContactDetails");
        }
    }
}
