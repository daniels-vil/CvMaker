using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvMaker.Data.Migrations
{
    public partial class LanguageSectionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "languageKnowledge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LanguageLevel = table.Column<int>(type: "int", nullable: false),
                    CurriculumVitaeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languageKnowledge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_languageKnowledge_curriculumVitae_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "curriculumVitae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_languageKnowledge_CurriculumVitaeId",
                table: "languageKnowledge",
                column: "CurriculumVitaeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "languageKnowledge");
        }
    }
}
