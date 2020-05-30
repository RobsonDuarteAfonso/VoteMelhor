using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VoteMelhor.Infra.Migrations
{
    public partial class ULTIMA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Party",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Initials = table.Column<string>(type: "varchar(50)", maxLength: 10, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "varchar(100)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Party", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Political",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CongressmanId = table.Column<int>(nullable: false),
                    SenatorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Image = table.Column<string>(type: "varchar(100)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Political", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proposal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    House = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    ProposalType = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Numeration = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Summary = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    ProposalDate = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Password_Code = table.Column<string>(type: "varchar(300)", maxLength: 20, nullable: true),
                    UserStatus = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    DtExpiraCodigo = table.Column<DateTime>(type: "DateTime", nullable: true),
                    CodigoConfirmacao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Role = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    State = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LawSuit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Summary = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "Datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Situation = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    PoliticalId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawSuit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LawSuit_Political_PoliticalId",
                        column: x => x.PoliticalId,
                        principalTable: "Political",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoliticalParty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Current = table.Column<int>(type: "int", nullable: false),
                    PoliticalId = table.Column<Guid>(nullable: false),
                    PartyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticalParty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliticalParty_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoliticalParty_Political_PoliticalId",
                        column: x => x.PoliticalId,
                        principalTable: "Political",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Current = table.Column<int>(type: "int", nullable: false),
                    PoliticalId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_Political_PoliticalId",
                        column: x => x.PoliticalId,
                        principalTable: "Political",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Vote = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    VotingDate = table.Column<DateTime>(type: "Datetime", nullable: false),
                    PoliticalId = table.Column<Guid>(nullable: false),
                    ProposalId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voting_Political_PoliticalId",
                        column: x => x.PoliticalId,
                        principalTable: "Political",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voting_Proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Rate = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    PoliticalId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Political_PoliticalId",
                        column: x => x.PoliticalId,
                        principalTable: "Political",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LawSuit_PoliticalId",
                table: "LawSuit",
                column: "PoliticalId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParty_PartyId",
                table: "PoliticalParty",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParty_PoliticalId",
                table: "PoliticalParty",
                column: "PoliticalId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_PoliticalId",
                table: "Position",
                column: "PoliticalId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_PoliticalId",
                table: "Rating",
                column: "PoliticalId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Voting_PoliticalId",
                table: "Voting",
                column: "PoliticalId");

            migrationBuilder.CreateIndex(
                name: "IX_Voting_ProposalId",
                table: "Voting",
                column: "ProposalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LawSuit");

            migrationBuilder.DropTable(
                name: "PoliticalParty");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Voting");

            migrationBuilder.DropTable(
                name: "Party");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Political");

            migrationBuilder.DropTable(
                name: "Proposal");
        }
    }
}
