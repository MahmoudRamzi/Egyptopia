using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egyptopia.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class gggg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExprience_AspNetUsers_ApplicationUserId",
                table: "UserExprience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExprience",
                table: "UserExprience");

            migrationBuilder.RenameTable(
                name: "UserExprience",
                newName: "UserExpriences");

            migrationBuilder.RenameIndex(
                name: "IX_UserExprience_ApplicationUserId",
                table: "UserExpriences",
                newName: "IX_UserExpriences_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExpriences",
                table: "UserExpriences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExpriences_AspNetUsers_ApplicationUserId",
                table: "UserExpriences",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExpriences_AspNetUsers_ApplicationUserId",
                table: "UserExpriences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExpriences",
                table: "UserExpriences");

            migrationBuilder.RenameTable(
                name: "UserExpriences",
                newName: "UserExprience");

            migrationBuilder.RenameIndex(
                name: "IX_UserExpriences_ApplicationUserId",
                table: "UserExprience",
                newName: "IX_UserExprience_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExprience",
                table: "UserExprience",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExprience_AspNetUsers_ApplicationUserId",
                table: "UserExprience",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
