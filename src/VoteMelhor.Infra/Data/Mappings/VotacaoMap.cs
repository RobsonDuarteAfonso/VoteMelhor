using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class VotacaoMap : IEntityTypeConfiguration<Votacao>
    {
        public void Configure(EntityTypeBuilder<Votacao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Voto)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.DtVotacao)
                .HasColumnType("Datetime")
                .IsRequired();

            builder.HasOne(c => c.Politico)
                .WithMany(c => c.Votacoes)
                .HasForeignKey(c => c.PoliticoId);

        }
    }
}
