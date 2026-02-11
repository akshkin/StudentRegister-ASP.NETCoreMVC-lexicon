using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegisterMVC.Migrations
{
    /// <inheritdoc />
    public partial class CreateJoinTablesWithClassroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomStudent_Classrooms_ClassroomsClassroomId",
                table: "ClassroomStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomStudent_Students_StudentsStudentId",
                table: "ClassroomStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomTeacher_Classrooms_ClassroomsClassroomId",
                table: "ClassroomTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomTeacher_Teachers_TeachersTeacherId",
                table: "ClassroomTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassroomTeacher",
                table: "ClassroomTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassroomStudent",
                table: "ClassroomStudent");

            migrationBuilder.RenameTable(
                name: "ClassroomTeacher",
                newName: "ClassroomTeachers");

            migrationBuilder.RenameTable(
                name: "ClassroomStudent",
                newName: "ClassroomStudents");

            migrationBuilder.RenameIndex(
                name: "IX_ClassroomTeacher_TeachersTeacherId",
                table: "ClassroomTeachers",
                newName: "IX_ClassroomTeachers_TeachersTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassroomStudent_StudentsStudentId",
                table: "ClassroomStudents",
                newName: "IX_ClassroomStudents_StudentsStudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassroomTeachers",
                table: "ClassroomTeachers",
                columns: new[] { "ClassroomsClassroomId", "TeachersTeacherId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassroomStudents",
                table: "ClassroomStudents",
                columns: new[] { "ClassroomsClassroomId", "StudentsStudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomStudents_Classrooms_ClassroomsClassroomId",
                table: "ClassroomStudents",
                column: "ClassroomsClassroomId",
                principalTable: "Classrooms",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomStudents_Students_StudentsStudentId",
                table: "ClassroomStudents",
                column: "StudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomTeachers_Classrooms_ClassroomsClassroomId",
                table: "ClassroomTeachers",
                column: "ClassroomsClassroomId",
                principalTable: "Classrooms",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomTeachers_Teachers_TeachersTeacherId",
                table: "ClassroomTeachers",
                column: "TeachersTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomStudents_Classrooms_ClassroomsClassroomId",
                table: "ClassroomStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomStudents_Students_StudentsStudentId",
                table: "ClassroomStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomTeachers_Classrooms_ClassroomsClassroomId",
                table: "ClassroomTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomTeachers_Teachers_TeachersTeacherId",
                table: "ClassroomTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassroomTeachers",
                table: "ClassroomTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassroomStudents",
                table: "ClassroomStudents");

            migrationBuilder.RenameTable(
                name: "ClassroomTeachers",
                newName: "ClassroomTeacher");

            migrationBuilder.RenameTable(
                name: "ClassroomStudents",
                newName: "ClassroomStudent");

            migrationBuilder.RenameIndex(
                name: "IX_ClassroomTeachers_TeachersTeacherId",
                table: "ClassroomTeacher",
                newName: "IX_ClassroomTeacher_TeachersTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassroomStudents_StudentsStudentId",
                table: "ClassroomStudent",
                newName: "IX_ClassroomStudent_StudentsStudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassroomTeacher",
                table: "ClassroomTeacher",
                columns: new[] { "ClassroomsClassroomId", "TeachersTeacherId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassroomStudent",
                table: "ClassroomStudent",
                columns: new[] { "ClassroomsClassroomId", "StudentsStudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomStudent_Classrooms_ClassroomsClassroomId",
                table: "ClassroomStudent",
                column: "ClassroomsClassroomId",
                principalTable: "Classrooms",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomStudent_Students_StudentsStudentId",
                table: "ClassroomStudent",
                column: "StudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomTeacher_Classrooms_ClassroomsClassroomId",
                table: "ClassroomTeacher",
                column: "ClassroomsClassroomId",
                principalTable: "Classrooms",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomTeacher_Teachers_TeachersTeacherId",
                table: "ClassroomTeacher",
                column: "TeachersTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
