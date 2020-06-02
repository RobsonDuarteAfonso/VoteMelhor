using Microsoft.EntityFrameworkCore.Migrations;

namespace VoteMelhor.Infra.Migrations
{
    public partial class correcao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Participation",
                table: "Position",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Participation",
                table: "Position");
        }
    }
}
