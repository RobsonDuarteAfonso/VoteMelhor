using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class ClassificacaoMap : IEntityTypeConfiguration<Classificacao>
    {
        public void Configure(EntityTypeBuilder<Classificacao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Rate)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3)
                .IsRequired();

            builder.HasOne(c => c.Politico)
                .WithMany(c => c.Classificacoes)
                .HasForeignKey(c => c.PoliticoId);

            builder.HasOne(c => c.Usuario)
                .WithMany(c => c.Classificacoes)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
