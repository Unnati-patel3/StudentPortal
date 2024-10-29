using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSujectsColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "StudentGrades",
                newName: "Subject");

            migrationBuilder.AddColumn<string>(
                name: "Semester",
                table: "StudentGrades",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Semester",
                table: "StudentGrades");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Subjects",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "StudentGrades",
                newName: "SubjectName");
        }
    }
}
