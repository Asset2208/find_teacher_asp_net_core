using Microsoft.EntityFrameworkCore.Migrations;

namespace FindTeacher.Data.Migrations
{
    public partial class CreateSystemFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemFeedbackCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemFeedbackCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemFeedbackCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemFeedbacks_SystemFeedbackCategories_SystemFeedbackCategoryId",
                        column: x => x.SystemFeedbackCategoryId,
                        principalTable: "SystemFeedbackCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemFeedbacks_SystemFeedbackCategoryId",
                table: "SystemFeedbacks",
                column: "SystemFeedbackCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemFeedbacks");

            migrationBuilder.DropTable(
                name: "SystemFeedbackCategories");
        }
    }
}
