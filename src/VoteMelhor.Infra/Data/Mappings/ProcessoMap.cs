using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class ProcessoMap : IEntityTypeConfiguration<Processo>
    {
        public void Configure(EntityTypeBuilder<Processo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Resumo)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Detalhe)
                .HasColumnType("varchar(2000)")
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(c => c.Situacao)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.DtAtualizacao)
                .HasColumnType("Datetime");

            builder.Property(c => c.DtAtualizacao)
                .HasColumnType("Datetime");

            builder.HasOne(c => c.Politico)
                .WithMany(c => c.Processos)
                .HasForeignKey(c => c.PoliticoId);
        }
    }
}
