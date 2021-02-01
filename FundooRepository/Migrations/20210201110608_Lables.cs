using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class Lables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundooNotes_Users_UserId",
                table: "FundooNotes");

            migrationBuilder.DropIndex(
                name: "IX_FundooNotes_UserId",
                table: "FundooNotes");

            migrationBuilder.CreateTable(
                name: "Lables",
                columns: table => new
                {
                    LableId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Lable = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lables", x => x.LableId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lables");

            migrationBuilder.CreateIndex(
                name: "IX_FundooNotes_UserId",
                table: "FundooNotes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundooNotes_Users_UserId",
                table: "FundooNotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
