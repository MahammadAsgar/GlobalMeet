using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalMeet.DataAccess.Migrations
{
    public partial class archivedMeetRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetDates_ArchivedMeets_ArchivedMeetId",
                table: "MeetDates");

            migrationBuilder.DropTable(
                name: "ArchivedMeets");

            migrationBuilder.DropIndex(
                name: "IX_MeetDates_ArchivedMeetId",
                table: "MeetDates");

            migrationBuilder.DropColumn(
                name: "ArchivedMeetId",
                table: "MeetDates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArchivedMeetId",
                table: "MeetDates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArchivedMeets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUserId = table.Column<int>(type: "int", nullable: true),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivedMeets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivedMeets_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetDates_ArchivedMeetId",
                table: "MeetDates",
                column: "ArchivedMeetId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivedMeets_AppUserId",
                table: "ArchivedMeets",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetDates_ArchivedMeets_ArchivedMeetId",
                table: "MeetDates",
                column: "ArchivedMeetId",
                principalTable: "ArchivedMeets",
                principalColumn: "Id");
        }
    }
}
