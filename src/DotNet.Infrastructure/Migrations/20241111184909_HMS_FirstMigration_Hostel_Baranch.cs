using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HMS_FirstMigration_Hostel_Baranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.EnsureSchema(
                name: "com");

            migrationBuilder.EnsureSchema(
                name: "core");

            

            migrationBuilder.CreateTable(
                name: "Hostels",
                schema: "core",
                columns: table => new
                {
                    HostelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalBranches = table.Column<int>(type: "int", nullable: false),
                    EstablishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HostelManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostels", x => x.HostelId);
                });

            
            migrationBuilder.CreateTable(
                name: "Branches",
                schema: "core",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HostelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branches_Hostels_HostelId",
                        column: x => x.HostelId,
                        principalSchema: "core",
                        principalTable: "Hostels",
                        principalColumn: "HostelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_HostelId",
                schema: "core",
                table: "Branches",
                column: "HostelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "com");

            migrationBuilder.DropTable(
                name: "Branches",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Designations",
                schema: "core");

            migrationBuilder.DropTable(
                name: "GlobalSettings",
                schema: "core");

            migrationBuilder.DropTable(
                name: "NotificationAreas",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Organizations",
                schema: "com");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "core");

            migrationBuilder.DropTable(
                name: "PermissionUserRoleMaps",
                schema: "core");

            migrationBuilder.DropTable(
                name: "SMSNotifications",
                schema: "core");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "com");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Hostels",
                schema: "core");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }
    }
}
