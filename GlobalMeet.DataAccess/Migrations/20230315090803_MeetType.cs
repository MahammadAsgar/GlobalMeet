using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalMeet.DataAccess.Migrations
{
    public partial class MeetType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "MeetDates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MeetTypeId",
                table: "MeetDates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MeetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegUserId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUserId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetDates_MeetTypeId",
                table: "MeetDates",
                column: "MeetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetDates_MeetTypes_MeetTypeId",
                table: "MeetDates",
                column: "MeetTypeId",
                principalTable: "MeetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetDates_MeetTypes_MeetTypeId",
                table: "MeetDates");

            migrationBuilder.DropTable(
                name: "MeetTypes");

            migrationBuilder.DropIndex(
                name: "IX_MeetDates_MeetTypeId",
                table: "MeetDates");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "MeetDates");

            migrationBuilder.DropColumn(
                name: "MeetTypeId",
                table: "MeetDates");
        }
    }
}
