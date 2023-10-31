using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoNajotEdu.Infrastructure.Migrations
{
    public partial class UserUploadFileAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UploadFile",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadFile",
                table: "Users");
        }
    }
}
