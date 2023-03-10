using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalMeet.DataAccess.Migrations
{
    public partial class MeetDateMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetDates_AspNetUsers_AppUserId",
                table: "MeetDates");

            migrationBuilder.DropTable(
                name: "CompanyProfession");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropColumn(
                name: "ConsultationCost",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "MeetDates",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetDates_AppUserId",
                table: "MeetDates",
                newName: "IX_MeetDates_CategoryId");

            migrationBuilder.AddColumn<decimal>(
                name: "ConsultationCost",
                table: "MeetDates",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyCategoryId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegUserId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUserId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegUserId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUserId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCategories", x => x.Id);
                });

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
                name: "IX_Companies_CompanyCategoryId",
                table: "Companies",
                column: "CompanyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCompany_CompaniesId",
                table: "CategoryCompany",
                column: "CompaniesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyCategories_CompanyCategoryId",
                table: "Companies",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetDates_Categories_CategoryId",
                table: "MeetDates",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyCategories_CompanyCategoryId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetDates_Categories_CategoryId",
                table: "MeetDates");

            migrationBuilder.DropTable(
                name: "CategoryCompany");

            migrationBuilder.DropTable(
                name: "CompanyCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyCategoryId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ConsultationCost",
                table: "MeetDates");

            migrationBuilder.DropColumn(
                name: "CompanyCategoryId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "MeetDates",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetDates_CategoryId",
                table: "MeetDates",
                newName: "IX_MeetDates_AppUserId");

            migrationBuilder.AddColumn<decimal>(
                name: "ConsultationCost",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditUserId = table.Column<int>(type: "int", nullable: true),
                    ProfessionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProfession",
                columns: table => new
                {
                    CompaniesId = table.Column<int>(type: "int", nullable: false),
                    ProfessionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfession", x => new { x.CompaniesId, x.ProfessionsId });
                    table.ForeignKey(
                        name: "FK_CompanyProfession_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyProfession_Professions_ProfessionsId",
                        column: x => x.ProfessionsId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfession_ProfessionsId",
                table: "CompanyProfession",
                column: "ProfessionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetDates_AspNetUsers_AppUserId",
                table: "MeetDates",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
