﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VoteMelhor.Infra.Data;

namespace VoteMelhor.Infra.Migrations
{
    [DbContext(typeof(VoteMelhorContext))]
    [Migration("20200318224338_ratepublico")]
    partial class ratepublico
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VoteMelhor.ApplicationCore.Entities.Classificacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PoliticoId")
                        .HasColumnType("uniqueidentifier");

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

            modelBuilder.Entity("VoteMelhor.ApplicationCore.Entities.Partido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imagem")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("VoteMelhor.ApplicationCore.Entities.Politico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(12);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Politicos");
                });

            modelBuilder.Entity("VoteMelhor.ApplicationCore.Entities.PoliticoPartido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PartidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PoliticoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PartidoId");

                    b.HasIndex("PoliticoId");

                    b.ToTable("PoliticoPartidos");
                });

            modelBuilder.Entity("VoteMelhor.ApplicationCore.Entities.Processo", b =>
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

                    b.Property<Guid>("PoliticoId")
                        .HasColumnType("uniqueidentifier");

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

            modelBuilder.Entity("VoteMelhor.ApplicationCore.Entities.Proposta", b =>
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

            modelBuilder.Entity("VoteMelhor.ApplicationCore.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("VoteMelhor.ApplicationCore.Entities.Votacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DtVotacao")
                        .HasColumnType("Datetime");

                    b.Property<Guid>("PoliticoId")
                        .HasColumnType("uniqueidentifier");

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

            modelBuilder.Entity("VoteMelhor.ApplicationCore.Entities.Classificacao", b =>
                {
                    b.HasOne("VoteMelhor.ApplicationCore.Entities.Politico", "Politico")
                        .WithMany("Classificacoes")
                        .HasForeignKey("PoliticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoteMelhor.ApplicationCore.Entities.Usuario", "Usuario")
                        .WithMany("Classificacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VoteMelhor.ApplicationCore.Entities.PoliticoPartido", b =>
                {
                    b.HasOne("VoteMelhor.ApplicationCore.Entities.Partido", "Partido")
                        .WithMany("PoliticoPartidos")
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoteMelhor.ApplicationCore.Entities.Politico", "Politico")
                        .WithMany("PoliticoPartidos")
                        .HasForeignKey("PoliticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VoteMelhor.ApplicationCore.Entities.Processo", b =>
                {
                    b.HasOne("VoteMelhor.ApplicationCore.Entities.Politico", "Politico")
                        .WithMany("Processos")
                        .HasForeignKey("PoliticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VoteMelhor.ApplicationCore.Entities.Votacao", b =>
                {
                    b.HasOne("VoteMelhor.ApplicationCore.Entities.Politico", "Politico")
                        .WithMany("Votacoes")
                        .HasForeignKey("PoliticoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoteMelhor.ApplicationCore.Entities.Proposta", "Proposta")
                        .WithMany()
                        .HasForeignKey("PropostaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
