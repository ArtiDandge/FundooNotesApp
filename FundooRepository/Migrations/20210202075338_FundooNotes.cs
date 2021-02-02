using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class FundooNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundooNotes",
                columns: table => new
                {
                    NotesId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Reminder = table.Column<string>(nullable: true),
                    Collaborator = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Lable = table.Column<string>(nullable: true),
                    Pin = table.Column<bool>(nullable: false, defaultValue: false),
                    Archieve = table.Column<bool>(nullable: false, defaultValue: false),
                    Is_Trash = table.Column<bool>(nullable: false, defaultValue: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundooNotes", x => x.NotesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundooNotes");
        }
    }
}
