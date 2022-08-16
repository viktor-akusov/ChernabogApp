using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChernabogApp.Migrations
{
    public partial class NewTypesOfMotion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Fly",
                table: "Monster",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Swim",
                table: "Monster",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Teleport",
                table: "Monster",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fly",
                table: "Monster");

            migrationBuilder.DropColumn(
                name: "Swim",
                table: "Monster");

            migrationBuilder.DropColumn(
                name: "Teleport",
                table: "Monster");
        }
    }
}
