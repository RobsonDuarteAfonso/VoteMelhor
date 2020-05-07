using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class RatingMap : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Rating");
            
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Rate)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3);

            builder.HasOne(c => c.Political)
                .WithMany(c => c.Ratings)
                .HasForeignKey(c => c.PoliticalId);

            builder.HasOne(c => c.User)
                .WithMany(c => c.Ratings)
                .HasForeignKey(c => c.UserId);
        }
    }
}
