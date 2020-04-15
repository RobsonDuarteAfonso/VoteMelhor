using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Senha)
                .HasColumnType("varchar(12)")
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(c => c.Facebook)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.Status)
                .HasColumnType("int");

            builder.Property(c => c.CodigoConfirmacao)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.Perfil)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.HasMany(c => c.Classificacoes)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
