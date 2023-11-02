using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoNajotEdu.Infrastructure.Migrations
{
    public partial class AddedLessonIsDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDone",
                table: "Lessons",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDone",
                table: "Lessons");
        }
    }
}
