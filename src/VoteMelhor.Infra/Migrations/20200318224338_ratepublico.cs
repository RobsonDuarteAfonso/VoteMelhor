using Microsoft.EntityFrameworkCore.Migrations;

namespace VoteMelhor.Infra.Migrations
{
    public partial class ratepublico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RatePublico",
                table: "Classificacoes",
                type: "varchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatePublico",
                table: "Classificacoes");
        }
    }
}
