using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class PartidoMap : IEntityTypeConfiguration<Partido>
    {
        public void Configure(EntityTypeBuilder<Partido> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Sigla)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(c => c.Numero)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Imagem)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.HasMany(c => c.PoliticoPartidos)
                .WithOne(c => c.Partido)
                .HasForeignKey(c => c.PartidoId);
        }
    }
}

