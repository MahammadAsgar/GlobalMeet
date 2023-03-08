using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalMeet.DataAccess.Migrations
{
    public partial class aboutMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Abouts_AboutId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AboutId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Abouts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_AppUserId",
                table: "Abouts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_AspNetUsers_AppUserId",
                table: "Abouts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_AspNetUsers_AppUserId",
                table: "Abouts");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_AppUserId",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Abouts");

            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AboutId",
                table: "AspNetUsers",
                column: "AboutId",
                unique: true,
                filter: "[AboutId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Abouts_AboutId",
                table: "AspNetUsers",
                column: "AboutId",
                principalTable: "Abouts",
                principalColumn: "Id");
        }
    }
}
