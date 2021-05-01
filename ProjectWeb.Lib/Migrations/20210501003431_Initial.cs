using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectWeb.Lib.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    IdCourse = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.IdCourse);
                });

            migrationBuilder.CreateTable(
                name: "Departament",
                columns: table => new
                {
                    DepartamentName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departament", x => x.DepartamentName);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    IdTeacher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentName1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.IdTeacher);
                    table.ForeignKey(
                        name: "FK_Teacher_Departament_DepartamentName1",
                        column: x => x.DepartamentName1,
                        principalTable: "Departament",
                        principalColumn: "DepartamentName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    IdSubject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grades = table.Column<double>(type: "float", nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: false),
                    CourseIdCourse = table.Column<int>(type: "int", nullable: true),
                    IdTeacher = table.Column<int>(type: "int", nullable: false),
                    TeacherIdTeacher = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.IdSubject);
                    table.ForeignKey(
                        name: "FK_Subject_Course_CourseIdCourse",
                        column: x => x.CourseIdCourse,
                        principalTable: "Course",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_Teacher_TeacherIdTeacher",
                        column: x => x.TeacherIdTeacher,
                        principalTable: "Teacher",
                        principalColumn: "IdTeacher",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CourseIdCourse",
                table: "Subject",
                column: "CourseIdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TeacherIdTeacher",
                table: "Subject",
                column: "TeacherIdTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_DepartamentName1",
                table: "Teacher",
                column: "DepartamentName1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Departament");
        }
    }
}
