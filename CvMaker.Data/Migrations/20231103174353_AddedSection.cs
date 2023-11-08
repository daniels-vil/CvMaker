using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvMaker.Data.Migrations
{
    public partial class AddedSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfSchool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Faculty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StudyProgram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EducationalLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StudyStartDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: true),
                    StudyEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurriculumVitaeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_education_curriculumVitae_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "curriculumVitae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfCompany = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JobPosition = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    WorkLoad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DurationOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurriculumVitaeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employment_curriculumVitae_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "curriculumVitae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SkillDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CurriculumVitaeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_skills_curriculumVitae_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "curriculumVitae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_education_CurriculumVitaeId",
                table: "education",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_employment_CurriculumVitaeId",
                table: "employment",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_skills_CurriculumVitaeId",
                table: "skills",
                column: "CurriculumVitaeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "education");

            migrationBuilder.DropTable(
                name: "employment");

            migrationBuilder.DropTable(
                name: "skills");
        }
    }
}
