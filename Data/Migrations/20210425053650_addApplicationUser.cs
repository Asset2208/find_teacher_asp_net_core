using Microsoft.EntityFrameworkCore.Migrations;

namespace FindTeacher.Data.Migrations
{
    public partial class addApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_IdentityUserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Comments",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_IdentityUserId",
                table: "Comments",
                newName: "IX_Comments_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Comments",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments",
                newName: "IX_Comments_IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_IdentityUserId",
                table: "Comments",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
