using Microsoft.EntityFrameworkCore;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Infra.Data.Mappings;

namespace VoteMelhor.Infra.Data
{
    public class VoteMelhorContext : DbContext
    {
        public VoteMelhorContext(DbContextOptions<VoteMelhorContext> options) : base(options) { }

        public VoteMelhorContext()
        {

        }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Party> Partys { get; set; }
        public DbSet<Political> Politicals { get; set; }
        public DbSet<PoliticalParty> PoliticalPartys { get; set; }
        public DbSet<LawSuit> LawSuits { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Voting> Votings { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PositionMap());
            modelBuilder.ApplyConfiguration(new RatingMap());
            modelBuilder.ApplyConfiguration(new PartyMap());
            modelBuilder.ApplyConfiguration(new PoliticalMap());
            modelBuilder.ApplyConfiguration(new PoliticalPartyMap());
            modelBuilder.ApplyConfiguration(new LawSuitMap());
            modelBuilder.ApplyConfiguration(new ProposalMap());
            modelBuilder.ApplyConfiguration(new VotingMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
