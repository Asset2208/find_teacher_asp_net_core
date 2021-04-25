using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindTeacher.Data.Migrations
{
    public partial class CreateTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTeachOnline = table.Column<bool>(type: "bit", nullable: false),
                    SubjectsTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Story = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabledAccount = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teachers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAchievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AchievementTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherAchievements_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherEducations_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherExperiences_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAchievements_TeacherId",
                table: "TeacherAchievements",
                column: "TeacherId",
                unique: true,
                filter: "[TeacherId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherEducations_TeacherId",
                table: "TeacherEducations",
                column: "TeacherId",
                unique: true,
                filter: "[TeacherId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherExperiences_TeacherId",
                table: "TeacherExperiences",
                column: "TeacherId",
                unique: true,
                filter: "[TeacherId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ApplicationUserId",
                table: "Teachers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CityId",
                table: "Teachers",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherAchievements");

            migrationBuilder.DropTable(
                name: "TeacherEducations");

            migrationBuilder.DropTable(
                name: "TeacherExperiences");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
