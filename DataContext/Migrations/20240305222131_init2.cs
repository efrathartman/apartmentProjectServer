using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContext.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "UrlImages",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImages",
                table: "Apartments");

            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
