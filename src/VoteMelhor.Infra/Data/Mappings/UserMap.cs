using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.OwnsOne(c => c.Password)
                .Property(c => c.Code)
                .HasColumnType("varchar(300)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.UserStatus)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.OwnsOne(c => c.ConfirmationCode)
                .Property(c => c.Code)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .HasColumnName("CodigoConfirmacao");

            builder.OwnsOne(c => c.ConfirmationCode)
                .Property(c => c.CodeExpirationDate)
                .HasColumnType("DateTime")
                .HasColumnName("DtExpiraCodigo");

            builder.Property(c => c.Role)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.State)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();                

            builder.HasMany(c => c.Ratings)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}
