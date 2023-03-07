using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalMeet.DataAccess.Migrations
{
    public partial class UpdateMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArchivedMeetId",
                table: "MeetDates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeetDates_ArchivedMeetId",
                table: "MeetDates",
                column: "ArchivedMeetId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetDates_ArchivedMeets_ArchivedMeetId",
                table: "MeetDates",
                column: "ArchivedMeetId",
                principalTable: "ArchivedMeets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetDates_ArchivedMeets_ArchivedMeetId",
                table: "MeetDates");

            migrationBuilder.DropIndex(
                name: "IX_MeetDates_ArchivedMeetId",
                table: "MeetDates");

            migrationBuilder.DropColumn(
                name: "ArchivedMeetId",
                table: "MeetDates");
        }
    }
}
