using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.OwnsOne(c => c.Senha)
                .Property(c => c.Codigo)
                .HasColumnType("varchar(300)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.StatusUsuario)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.OwnsOne(c => c.CodigoConfirmacao)
                .Property(c => c.Codigo)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .HasColumnName("CodigoConfirmacao");

            builder.OwnsOne(c => c.CodigoConfirmacao)
                .Property(c => c.DtExpiraCodigo)
                .HasColumnType("DateTime")
                .HasColumnName("DtExpiraCodigo");

            builder.Property(c => c.Perfil)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.Estado)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();                

            builder.HasMany(c => c.Classificacoes)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
