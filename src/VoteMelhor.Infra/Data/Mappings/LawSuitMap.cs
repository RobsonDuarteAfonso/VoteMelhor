using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class LawSuitMap : IEntityTypeConfiguration<LawSuit>
    {
        public void Configure(EntityTypeBuilder<LawSuit> builder)
        {
            builder.ToTable("LawSuit");
            
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Summary)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar(2000)")
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(c => c.Situation)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.PublicationDate)
                .HasColumnType("Datetime");

            builder.Property(c => c.UpdateDate)
                .HasColumnType("Datetime");

            builder.HasOne(c => c.Political)
                .WithMany(c => c.LawSuits)
                .HasForeignKey(c => c.PoliticalId);
        }
    }
}
