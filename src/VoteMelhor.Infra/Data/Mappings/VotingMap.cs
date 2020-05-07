using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class VotingMap : IEntityTypeConfiguration<Voting>
    {
        public void Configure(EntityTypeBuilder<Voting> builder)
        {
            builder.ToTable("Voting");
            
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Vote)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.VotingDate)
                .HasColumnType("Datetime")
                .IsRequired();

            builder.HasOne(c => c.Political)
                .WithMany(c => c.Votings)
                .HasForeignKey(c => c.PoliticalId);

        }
    }
}
