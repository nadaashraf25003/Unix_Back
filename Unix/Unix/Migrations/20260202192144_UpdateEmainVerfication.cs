using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unix.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmainVerfication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmailVerificationCodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "EmailVerificationCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stage",
                table: "EmailVerificationCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmailVerificationCodes");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "EmailVerificationCodes");

            migrationBuilder.DropColumn(
                name: "Stage",
                table: "EmailVerificationCodes");
        }
    }
}
