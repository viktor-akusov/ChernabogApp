using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChernabogApp.Migrations
{
    public partial class NullableMonsterCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monster_MonsterCategory_CategoryId",
                table: "Monster");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Monster",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Monster_MonsterCategory_CategoryId",
                table: "Monster",
                column: "CategoryId",
                principalTable: "MonsterCategory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monster_MonsterCategory_CategoryId",
                table: "Monster");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Monster",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Monster_MonsterCategory_CategoryId",
                table: "Monster",
                column: "CategoryId",
                principalTable: "MonsterCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
