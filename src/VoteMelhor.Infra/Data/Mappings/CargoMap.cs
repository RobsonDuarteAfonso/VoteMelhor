using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("Cargo");
            
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Atual)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(c => c.Politico)
                .WithMany(c => c.Cargos)
                .HasForeignKey(c => c.PoliticoId);
        }
    }
}
