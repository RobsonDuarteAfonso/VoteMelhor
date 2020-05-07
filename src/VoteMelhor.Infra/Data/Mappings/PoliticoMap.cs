using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class PoliticoMap : IEntityTypeConfiguration<Politico>
    {
        public void Configure(EntityTypeBuilder<Politico> builder)
        {
            builder.ToTable("Politico");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Estado)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.Imagem)
                .HasColumnType("varchar(100)")
                .HasMaxLength(12)
                .IsRequired();

             builder.HasMany(c => c.PoliticoPartidos)
                .WithOne(c => c.Politico)
                .HasForeignKey(c => c.PoliticoId);

            builder.HasMany(c => c.Processos)
               .WithOne(c => c.Politico)
               .HasForeignKey(c => c.PoliticoId);

            builder.HasMany(c => c.Votacoes)
               .WithOne(c => c.Politico)
               .HasForeignKey(c => c.PoliticoId);

            builder.HasMany(c => c.Classificacoes)
               .WithOne(c => c.Politico)
               .HasForeignKey(c => c.PoliticoId);

            builder.HasMany(c => c.Cargos)
               .WithOne(c => c.Politico)
               .HasForeignKey(c => c.PoliticoId);
        }
    }
}
