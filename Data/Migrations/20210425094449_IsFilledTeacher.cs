using Microsoft.EntityFrameworkCore.Migrations;

namespace FindTeacher.Data.Migrations
{
    public partial class IsFilledTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Is_Filled_Achievement",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Is_Filled_Education",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Is_Filled_Experience",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Is_Filled_Achievement",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Is_Filled_Education",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Is_Filled_Experience",
                table: "Teachers");
        }
    }
}
