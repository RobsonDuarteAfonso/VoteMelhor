using System;
using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Queries;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class ProposalRepository : Repository<Proposal>, IProposalRepository
    {
        public ProposalRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public Proposal VerifyExist(Guid id)
        {
            return DbSet.FirstOrDefault(ProposalQueries.VerifyExist(id));
        }
    }
}
