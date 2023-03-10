using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalMeet.DataAccess.Migrations
{
    public partial class AboutFixMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Abouts_AboutId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "CategoryCompany");

            migrationBuilder.DropIndex(
                name: "IX_Companies_AboutId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "ProfessionTitle",
                table: "Categories",
                newName: "CategoryTitle");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_CompanyId",
                table: "Abouts",
                column: "CompanyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_Companies_CompanyId",
                table: "Abouts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_Companies_CompanyId",
                table: "Abouts");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_CompanyId",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "CategoryTitle",
                table: "Categories",
                newName: "ProfessionTitle");

            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryCompany",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    CompaniesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCompany", x => new { x.CategoriesId, x.CompaniesId });
                    table.ForeignKey(
                        name: "FK_CategoryCompany_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCompany_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AboutId",
                table: "Companies",
                column: "AboutId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCompany_CompaniesId",
                table: "CategoryCompany",
                column: "CompaniesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Abouts_AboutId",
                table: "Companies",
                column: "AboutId",
                principalTable: "Abouts",
                principalColumn: "Id");
        }
    }
}
