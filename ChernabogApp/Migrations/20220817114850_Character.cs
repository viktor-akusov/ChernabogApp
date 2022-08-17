using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChernabogApp.Migrations
{
    public partial class Character : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    CharClassId = table.Column<int>(type: "integer", nullable: false),
                    Purporse = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<byte>(type: "smallint", nullable: false),
                    Experience = table.Column<long>(type: "bigint", nullable: false),
                    Magnificence = table.Column<long>(type: "bigint", nullable: false),
                    RerollsMax = table.Column<byte>(type: "smallint", nullable: false),
                    Hunger = table.Column<byte>(type: "smallint", nullable: false),
                    Thirst = table.Column<byte>(type: "smallint", nullable: false),
                    Strength = table.Column<byte>(type: "smallint", nullable: false),
                    Dexterity = table.Column<byte>(type: "smallint", nullable: false),
                    Constituiton = table.Column<byte>(type: "smallint", nullable: false),
                    Wisdom = table.Column<byte>(type: "smallint", nullable: false),
                    Intellgence = table.Column<byte>(type: "smallint", nullable: false),
                    Charisma = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_CharClass_CharClassId",
                        column: x => x.CharClassId,
                        principalTable: "CharClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_CharClassId",
                table: "Character",
                column: "CharClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_RaceId",
                table: "Character",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}
