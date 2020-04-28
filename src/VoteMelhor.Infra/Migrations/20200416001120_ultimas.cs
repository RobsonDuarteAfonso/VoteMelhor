using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VoteMelhor.Infra.Migrations
{
    public partial class ultimas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Sigla = table.Column<string>(type: "varchar(50)", maxLength: 10, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Politicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Imagem = table.Column<string>(type: "varchar(100)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Politicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propostas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CasaLegislativa = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    TipoProposta = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Numeracao = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Resumo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    DtProposta = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propostas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Facebook = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CodigoConfirmacao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Perfil = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Atual = table.Column<int>(type: "int", nullable: false),
                    PoliticoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargos_Politicos_PoliticoId",
                        column: x => x.PoliticoId,
                        principalTable: "Politicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoliticoPartidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Atual = table.Column<int>(type: "int", nullable: false),
                    PoliticoId = table.Column<int>(nullable: false),
                    PartidoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticoPartidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliticoPartidos_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoliticoPartidos_Politicos_PoliticoId",
                        column: x => x.PoliticoId,
                        principalTable: "Politicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Resumo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Detalhe = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    DtPublicacao = table.Column<DateTime>(nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Situacao = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    PoliticoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processos_Politicos_PoliticoId",
                        column: x => x.PoliticoId,
                        principalTable: "Politicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Voto = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    DtVotacao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    PoliticoId = table.Column<int>(nullable: false),
                    PropostaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votacoes_Politicos_PoliticoId",
                        column: x => x.PoliticoId,
                        principalTable: "Politicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votacoes_Propostas_PropostaId",
                        column: x => x.PropostaId,
                        principalTable: "Propostas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classificacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Rate = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    RatePublico = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    PoliticoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classificacoes_Politicos_PoliticoId",
                        column: x => x.PoliticoId,
                        principalTable: "Politicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classificacoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_PoliticoId",
                table: "Cargos",
                column: "PoliticoId");

            migrationBuilder.CreateIndex(
                name: "IX_Classificacoes_PoliticoId",
                table: "Classificacoes",
                column: "PoliticoId");

            migrationBuilder.CreateIndex(
                name: "IX_Classificacoes_UsuarioId",
                table: "Classificacoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticoPartidos_PartidoId",
                table: "PoliticoPartidos",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticoPartidos_PoliticoId",
                table: "PoliticoPartidos",
                column: "PoliticoId");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_PoliticoId",
                table: "Processos",
                column: "PoliticoId");

            migrationBuilder.CreateIndex(
                name: "IX_Votacoes_PoliticoId",
                table: "Votacoes",
                column: "PoliticoId");

            migrationBuilder.CreateIndex(
                name: "IX_Votacoes_PropostaId",
                table: "Votacoes",
                column: "PropostaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Classificacoes");

            migrationBuilder.DropTable(
                name: "PoliticoPartidos");

            migrationBuilder.DropTable(
                name: "Processos");

            migrationBuilder.DropTable(
                name: "Votacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Politicos");

            migrationBuilder.DropTable(
                name: "Propostas");
        }
    }
}
