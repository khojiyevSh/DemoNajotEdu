using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoNajotEdu.Infrastructure.Migrations
{
    public partial class addedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_users_TeacherId",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_users_UserName",
                table: "Users",
                newName: "IX_Users_UserName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "PasswordHash", "Role", "UserName" },
                values: new object[] { 1, "Adminov admin", "2646720E1B4B3B960107335AC274F819510741B41A2254C7F17FF39110C89919D0F10F29E2A5BAC9976E2CA3358B1AC65BDC63AEAB83B59F792F188EDE1C9846", 1, "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_TeacherId",
                table: "Groups",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_TeacherId",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserName",
                table: "users",
                newName: "IX_users_UserName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_users_TeacherId",
                table: "Groups",
                column: "TeacherId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
