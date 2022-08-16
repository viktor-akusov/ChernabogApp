using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChernabogApp.Migrations
{
    public partial class CategoryDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MonsterCategory",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MonsterCategory");
        }
    }
}
