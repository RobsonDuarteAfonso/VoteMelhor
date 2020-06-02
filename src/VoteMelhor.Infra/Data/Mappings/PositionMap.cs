using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class PositionMap : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");
            
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Participation)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();                

            builder.Property(c => c.Current)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(c => c.Political)
                .WithMany(c => c.Positions)
                .HasForeignKey(c => c.PoliticalId);
        }
    }
}
