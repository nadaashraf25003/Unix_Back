using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unix.Migrations
{
    /// <inheritdoc />
    public partial class EditColoms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TableUsageHistories_TableId",
                table: "TableUsageHistories",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_StageDrivers_DepartmentId",
                table: "StageDrivers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CourseId",
                table: "Exams",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_InstructorId",
                table: "Exams",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_RoomId",
                table: "Exams",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SectionId",
                table: "Exams",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Instructors_InstructorId",
                table: "Exams",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Rooms_RoomId",
                table: "Exams",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Sections_SectionId",
                table: "Exams",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StageDrivers_Departments_DepartmentId",
                table: "StageDrivers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TableUsageHistories_Tables_TableId",
                table: "TableUsageHistories",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Instructors_InstructorId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Rooms_RoomId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Sections_SectionId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_StageDrivers_Departments_DepartmentId",
                table: "StageDrivers");

            migrationBuilder.DropForeignKey(
                name: "FK_TableUsageHistories_Tables_TableId",
                table: "TableUsageHistories");

            migrationBuilder.DropIndex(
                name: "IX_TableUsageHistories_TableId",
                table: "TableUsageHistories");

            migrationBuilder.DropIndex(
                name: "IX_StageDrivers_DepartmentId",
                table: "StageDrivers");

            migrationBuilder.DropIndex(
                name: "IX_Exams_CourseId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_InstructorId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_RoomId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_SectionId",
                table: "Exams");
        }
    }
}
