using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class PartyMap : IEntityTypeConfiguration<Party>
    {
        public void Configure(EntityTypeBuilder<Party> builder)
        {
            builder.ToTable("Party");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Initials)
                .HasColumnType("varchar(50)")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(c => c.Number)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Image)
                .HasColumnType("varchar(100)")
                .HasMaxLength(50);

            builder.HasMany(c => c.PoliticalPartys)
                .WithOne(c => c.Party)
                .HasForeignKey(c => c.PartyId);
        }
    }
}

