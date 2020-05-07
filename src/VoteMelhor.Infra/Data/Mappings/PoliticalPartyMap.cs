using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class PoliticalPartyMap : IEntityTypeConfiguration<PoliticalParty>
    {
        public void Configure(EntityTypeBuilder<PoliticalParty> builder)
        {
            builder.ToTable("PoliticalParty");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Current)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(c => c.Political)
                .WithMany(c => c.PoliticalPartys)
                .HasForeignKey(c => c.PoliticalId);

            builder.HasOne(c => c.Party)
                .WithMany(c => c.PoliticalPartys)
                .HasForeignKey(c => c.PartyId);
        }
    }
}
