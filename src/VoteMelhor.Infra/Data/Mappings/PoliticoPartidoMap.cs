using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class PoliticoPartidoMap : IEntityTypeConfiguration<PoliticoPartido>
    {
        public void Configure(EntityTypeBuilder<PoliticoPartido> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Atual)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(c => c.Politico)
                .WithMany(c => c.PoliticoPartidos)
                .HasForeignKey(c => c.PoliticoId);

            builder.HasOne(c => c.Partido)
                .WithMany(c => c.PoliticoPartidos)
                .HasForeignKey(c => c.PartidoId);
        }
    }
}
