using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class PropostaMap : IEntityTypeConfiguration<Proposta>
    {
        public void Configure(EntityTypeBuilder<Proposta> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CasaLegislativa)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.TipoProposta)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.Numeracao)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.Resumo)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(2000)")
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(c => c.DtProposta)
                .HasColumnType("Datetime");

        }
    }
}
