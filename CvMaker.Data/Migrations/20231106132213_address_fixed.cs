using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvMaker.Data.Migrations
{
    public partial class address_fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeAddress",
                table: "address");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "address",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "address",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetNumber",
                table: "address",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "address");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "address");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "address");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "address");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "address");

            migrationBuilder.AddColumn<string>(
                name: "HomeAddress",
                table: "address",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
