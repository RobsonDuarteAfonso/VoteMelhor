using Microsoft.EntityFrameworkCore;
using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.Infra.Data.Mappings;

namespace VoteMelhor.Infra.Data
{
    public class VoteMelhorContext : DbContext
    {
        public VoteMelhorContext(DbContextOptions<VoteMelhorContext> options) : base(options) { }

        public VoteMelhorContext()
        {

        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Classificacao> Classificacoes { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Politico> Politicos { get; set; }
        public DbSet<PoliticoPartido> PoliticoPartidos { get; set; }
        public DbSet<Processo> Processos { get; set; }
        public DbSet<Proposta> Propostas { get; set; }
        public DbSet<Votacao> Votacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VoteMelhor;Data Source=PC-ROBSON\\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CargoMap());
            modelBuilder.ApplyConfiguration(new ClassificacaoMap());
            modelBuilder.ApplyConfiguration(new PartidoMap());
            modelBuilder.ApplyConfiguration(new PoliticoMap());
            modelBuilder.ApplyConfiguration(new PoliticoPartidoMap());
            modelBuilder.ApplyConfiguration(new ProcessoMap());
            modelBuilder.ApplyConfiguration(new PropostaMap());
            modelBuilder.ApplyConfiguration(new VotacaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
