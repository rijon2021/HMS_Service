using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseEntity1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "core",
                table: "Rooms",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                schema: "core",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "core",
                table: "Rooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                schema: "core",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "core",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                schema: "core",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "core",
                table: "Beds",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                schema: "core",
                table: "Beds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "core",
                table: "Beds",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                schema: "core",
                table: "Beds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "core",
                table: "Beds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                schema: "core",
                table: "Beds",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "core",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "core",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "core",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "core",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "core",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "core",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "core",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "core",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "core",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "core",
                table: "Beds");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "core",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "core",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
