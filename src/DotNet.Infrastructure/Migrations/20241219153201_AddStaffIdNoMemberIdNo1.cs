using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStaffIdNoMemberIdNo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StaffIdNo",
                schema: "core",
                table: "Staffs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberIdNo",
                schema: "core",
                table: "Members",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffIdNo",
                schema: "core",
                table: "Staffs",
                column: "StaffIdNo",
                unique: true,
                filter: "[StaffIdNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberIdNo",
                schema: "core",
                table: "Members",
                column: "MemberIdNo",
                unique: true,
                filter: "[MemberIdNo] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Staffs_StaffIdNo",
                schema: "core",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Members_MemberIdNo",
                schema: "core",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "StaffIdNo",
                schema: "core",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "MemberIdNo",
                schema: "core",
                table: "Members");
        }
    }
}
