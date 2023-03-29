using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalMeet.DataAccess.Migrations
{
    public partial class MeetTypeMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetDates_MeetTypes_MeetTypeId",
                table: "MeetDates");

            migrationBuilder.AlterColumn<int>(
                name: "MeetTypeId",
                table: "MeetDates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetDates_MeetTypes_MeetTypeId",
                table: "MeetDates",
                column: "MeetTypeId",
                principalTable: "MeetTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetDates_MeetTypes_MeetTypeId",
                table: "MeetDates");

            migrationBuilder.AlterColumn<int>(
                name: "MeetTypeId",
                table: "MeetDates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetDates_MeetTypes_MeetTypeId",
                table: "MeetDates",
                column: "MeetTypeId",
                principalTable: "MeetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
