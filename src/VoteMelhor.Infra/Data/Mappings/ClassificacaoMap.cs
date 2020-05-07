using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Infra.Data.Mappings
{
    public class ClassificacaoMap : IEntityTypeConfiguration<Classificacao>
    {
        public void Configure(EntityTypeBuilder<Classificacao> builder)
        {
            builder.ToTable("Classificacao");
            
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Rate)
                .HasColumnType("varchar(3)")
                .HasMaxLength(3);

            builder.HasOne(c => c.Politico)
                .WithMany(c => c.Classificacoes)
                .HasForeignKey(c => c.PoliticoId);

            builder.HasOne(c => c.Usuario)
                .WithMany(c => c.Classificacoes)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
