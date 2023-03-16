using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalMeet.DataAccess.Migrations
{
    public partial class CompanyApproveReject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TempId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Companies");
        }
    }
}
