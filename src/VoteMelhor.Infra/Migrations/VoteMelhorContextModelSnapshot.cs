﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VoteMelhor.Infra.Data;

namespace VoteMelhor.Infra.Migrations
{
    [DbContext(typeof(VoteMelhorContext))]
    partial class VoteMelhorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VoteMelhor.Domain.Entities.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Atual")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("PoliticoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PoliticoId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.Classificacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PoliticoId")
                        .HasColumnType("int");

                    b.Property<string>("Rate")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("RatePublico")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3);

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PoliticoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Classificacoes");
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.Partido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imagem")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.Politico", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(12);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Politicos");
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.PoliticoPartido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Atual")
                        .HasColumnType("int");

                    b.Property<Guid>("PartidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PoliticoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartidoId");

                    b.HasIndex("PoliticoId");

                    b.ToTable("PoliticoPartidos");
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.Processo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Detalhe")
                        .IsRequired()
                        .HasColumnType("varchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("DtAtualizacao")
                        .HasColumnType("Datetime");

                    b.Property<DateTime>("DtPublicacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("PoliticoId")
                        .HasColumnType("int");

                    b.Property<string>("Resumo")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.HasIndex("PoliticoId");

                    b.ToTable("Processos");
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.Proposta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CasaLegislativa")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("DtProposta")
                        .HasColumnType("Datetime");

                    b.Property<string>("Numeracao")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Resumo")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("TipoProposta")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.ToTable("Propostas");
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoConfirmacao")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Facebook")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(12)")
                        .HasMaxLength(12);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.Votacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DtVotacao")
                        .HasColumnType("Datetime");

                    b.Property<int>("PoliticoId")
                        .HasColumnType("int");

                    b.Property<Guid>("PropostaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Voto")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.HasIndex("PoliticoId");

                    b.HasIndex("PropostaId");

                    b.ToTable("Votacoes");
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.Cargo", b =>
                {
                    b.HasOne("VoteMelhor.Domain.Entities.Politico", "Politico")
                        .WithMany("Cargos")
                        .HasForeignKey("PoliticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.Classificacao", b =>
                {
                    b.HasOne("VoteMelhor.Domain.Entities.Politico", "Politico")
                        .WithMany("Classificacoes")
                        .HasForeignKey("PoliticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoteMelhor.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Classificacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.PoliticoPartido", b =>
                {
                    b.HasOne("VoteMelhor.Domain.Entities.Partido", "Partido")
                        .WithMany("PoliticoPartidos")
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoteMelhor.Domain.Entities.Politico", "Politico")
                        .WithMany("PoliticoPartidos")
                        .HasForeignKey("PoliticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.Processo", b =>
                {
                    b.HasOne("VoteMelhor.Domain.Entities.Politico", "Politico")
                        .WithMany("Processos")
                        .HasForeignKey("PoliticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VoteMelhor.Domain.Entities.Votacao", b =>
                {
                    b.HasOne("VoteMelhor.Domain.Entities.Politico", "Politico")
                        .WithMany("Votacoes")
                        .HasForeignKey("PoliticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoteMelhor.Domain.Entities.Proposta", "Proposta")
                        .WithMany()
                        .HasForeignKey("PropostaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
