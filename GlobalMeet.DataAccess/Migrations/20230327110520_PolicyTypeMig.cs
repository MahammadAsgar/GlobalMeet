using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalMeet.DataAccess.Migrations
{
    public partial class PolicyTypeMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PolicyType",
                table: "PrivacyPolicies",
                newName: "PolicyTypeId");

            migrationBuilder.CreateTable(
                name: "PolicyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegUserId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUserId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrivacyPolicies_PolicyTypeId",
                table: "PrivacyPolicies",
                column: "PolicyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivacyPolicies_PolicyTypes_PolicyTypeId",
                table: "PrivacyPolicies",
                column: "PolicyTypeId",
                principalTable: "PolicyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivacyPolicies_PolicyTypes_PolicyTypeId",
                table: "PrivacyPolicies");

            migrationBuilder.DropTable(
                name: "PolicyTypes");

            migrationBuilder.DropIndex(
                name: "IX_PrivacyPolicies_PolicyTypeId",
                table: "PrivacyPolicies");

            migrationBuilder.RenameColumn(
                name: "PolicyTypeId",
                table: "PrivacyPolicies",
                newName: "PolicyType");
        }
    }
}
